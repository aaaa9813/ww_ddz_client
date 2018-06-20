/*
* CPeer.cpp
*
*  Created on: 2011-12-29
*      Author: wangwei
*/

#include "CPeer.h"
#include "BitStream.h"



extern "C"  
{

	RakNet::RakPeerInterface *m_pPeer;
	///Socket描述
	//SocketDescriptor socketDescriptors[2];

	///使用IP地址或域名加端口连接到指定的主机。
	///参数[in]host 要连接主机的IP或主机域名。
	///参数[in]remotePort 要连接主机的端口。
	///参数[in]passwordData 要连接主机的密码。
	///参数[in]passwordDataLength 要连接主机的密码长度。
	///返回值见枚举ConnectionAttemptResult
	int Connect(const char *host,
		int remotePort,
		const char *passwordData,
		int passwordDataLength) {

			ConnectionAttemptResult result;

			result = m_pPeer->Connect(host, remotePort, passwordData, passwordDataLength);

			return (int)result;
	}

	///发送一块数据到指定的已连接的结点；
	///第一个字节为这条消息的唯一标识；
	///参数[in]data，表示要发送的数据；
	///参数[in]length，表示发送数据的长度；
	///参数[in]priority,表示发送数据的优先级，参见优先级描述；
	///参数[in]reliability,表示发送数据的可靠性，参见可靠性描述；
	///参数[in]systemIdentifer,接收者。
	///参数[in]broadcast 当为true时表示发送消息到所有的已连接结点。
	///返回值 0 表示参数有误. 其它数字标识此条信息.
	int Send(const char *data,
		const int length,
		PacketPriority priority,
		PacketReliability reliability,
		const AddressOrGUID systemIdentifier,
		bool broadcast) {
			uint32_t result;
			if (broadcast)
				result = m_pPeer->Send(data, length, priority, reliability, 0, UNASSIGNED_SYSTEM_ADDRESS,
				broadcast);
			else
				result = m_pPeer->Send(data, length, priority, reliability, 0, systemIdentifier, broadcast);

			return result;
	}

	uint32_t SendStream(const RakNet::BitStream *bitStream,
		PacketPriority priority,
		PacketReliability reliability,
		const AddressOrGUID systemIdentifier,
		bool broadcast) {
			uint32_t result;
			if (broadcast)
				result = m_pPeer->Send(bitStream, priority, reliability, 0, UNASSIGNED_SYSTEM_ADDRESS,
				broadcast);
			else
				result = m_pPeer->Send(bitStream, priority, reliability, 0, systemIdentifier, broadcast);

			return result;
	}

	int SendEx(int msgid, int msgid2, const char * data, const int len, unsigned long long sockindex)
	{

		if(m_Socketlist.find(sockindex) == m_Socketlist.end())
		{
			printf("error:sockindex %d is not find!\n",sockindex);
			assert(false);
			return -1;
		}

		AddressOrGUID guid = m_Socketlist[sockindex];

		RakNet::BitStream bitstream;
		bitstream.Write((char)msgid);
		bitstream.Write(msgid2);

		if(len > 0 && data != NULL)
		{
			bitstream.Write(data, len);
		}

		return SendStream(&bitstream, IMMEDIATE_PRIORITY, RELIABLE_ORDERED,guid, false);

	}
		
	
	int SendEx_1id(int msgid, const char * data, const int len, unsigned long long sockindex)
	{

		if(m_Socketlist.find(sockindex) == m_Socketlist.end())
		{
			printf("error:sockindex %d is not find!\n",sockindex);
			assert(false);
			return -1;
		}

		AddressOrGUID guid = m_Socketlist[sockindex];

		RakNet::BitStream bitstream;
		bitstream.Write((char)msgid);

		if(len > 0 && data != NULL)
		{
			bitstream.Write(data, len);
		}

		return SendStream(&bitstream, IMMEDIATE_PRIORITY, RELIABLE_ORDERED,guid, false);

	}




	/// 从消息队列获取一个消息.
	/// 处理完一个消息后使用DeallocatePacket()函数释放这个消息.
	/// 返回值 0 表示没有消息包，否则将返回消息包的指针.
	//Packet *Receive() {
	//	return m_pPeer->Receive();
	//}

	/// 当调用Receive（）处理完一个消息后，调用此函数将包释放
	/// 参数[in] packet 消息包的指针.
	void DeallocatePacket(Packet *packet) {
		m_pPeer->DeallocatePacket(packet);
	}

	///获取包的ID
	///参数[in]p 表示收到数据包的指针。
	///返回值为包的ID
	unsigned char GetPacketIdentifier(RakNet::Packet *p) {
		if (p == 0)
			return 255;

		if ((unsigned char) p->data[0] == ID_TIMESTAMP) {
			RakAssert(p->length > sizeof(RakNet::MessageID) + sizeof(RakNet::Time));
			return (unsigned char) p->data[sizeof(RakNet::MessageID) + sizeof(RakNet::Time)];
		}
		else
			return (unsigned char) p->data[0];
	}

	///断开连接后，所有连接该结点的用户都将收到此用户断开消息
	void Disconnect() {
		//    if (m_pNatPunchServer) {
		//        m_pNatPunchServer->Shutdown(m_pPeer);
		//        delete m_pNatPunchServer;
		//        m_pNatPunchServer = NULL;
		//    }
		m_pPeer->Shutdown(300);
	}

	///断开连接到本主机上的指定的客户端
	///参数[in] target表示要断开的客户端连接
	void CloseConnection(const AddressOrGUID target) {
		m_pPeer->CloseConnection(target, true, 0);
	}




	void MsgLoop()
	{
		RakNet::Packet* p;

		unsigned long long sockindex;

		for (p=m_pPeer->Receive(); p; m_pPeer->DeallocatePacket(p), p=m_pPeer->Receive())
		{
			unsigned char packetIdentifier = GetPacketIdentifier(p);

			const char * pGuid = p->guid.ToString();

#if   defined(WIN32)
		//	sockindex=_strtoui64(pGuid, NULL, 10);
			sockindex= p->guid.g;

#else
			// Changed from g=strtoull(pGuid,0,10); for android
			sockindex=strtoull(pGuid, (char **)NULL, 10);
#endif


			std::map<int, Func>::iterator it = m_MsgReglist.find((int)packetIdentifier);

			if(packetIdentifier == ID_CONNECTION_REQUEST_ACCEPTED
				||packetIdentifier == ID_NEW_INCOMING_CONNECTION)
			{
				
				m_Socketlist[sockindex] = p->guid;

			}

			if(it != m_MsgReglist.end())
			{
				it->second(it->first, p->data, p->length, sockindex);

				printf("call===%d\n", it->first);
			}
		}
	}



	void RegMsg(int msgid, Func fun)
	{

		m_MsgReglist[msgid] = fun;

		//	byte t[6];
		//	memcpy(t, "1234ab", sizeof(byte) * 6);
		////	strcpy(t, "12345a");
		//	int a = m_MsgReglist[msgid](t, 6);

		printf("===%d===\n",msgid);
	}
    

    void RegMsgtst(int msgid)
    {
        
    }
    
    void RegMsgtst1(int msgid, Func1 f)
    {
        
    }

	int MsgInit()
	{
		m_pPeer = RakPeerInterface::GetInstance();

		RakNet::SocketDescriptor socketDescriptor(0,0);

		socketDescriptor.port = 0;

		socketDescriptor.hostAddress[0] = 0;

		socketDescriptor.socketFamily = AF_INET; // Test out IPV4


		return m_pPeer->Startup(100, &socketDescriptor, 1);

	}
}

