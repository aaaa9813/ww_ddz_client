using System;
using System.Runtime.InteropServices;

public struct Stest{
public 	int	age;
public 	string	name;
};

//================================================
//[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
//public	struct PT_ENTER_GAME_REQUEST_INFO
//{
//	
//	public	int gameid;
//	public	int userid;
//	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
//	public string charname;
//	public	Int64 guid;
//	
//};

//====================================================

//RakNet::BitStream ws;
//ws.Write((unsigned char) PT_ENTER_GAME_REQUEST);
//ws.Write((unsigned int) serverid);
//ws.Write((unsigned int) gameid);
//ws.Write((unsigned int) uid);
//ws.Write((unsigned long long) 0);
//SendData(&ws, m_ServerAddr);


enum msg_id
{
	ID_CONNECTION_REQUEST_ACCEPTED = 16,

	ID_CONNECTION_ATTEMPT_FAILED,
	/// RakPeer - Sent a connect request to a system we are currently connected to.
	ID_ALREADY_CONNECTED,
	/// RakPeer - A remote system has successfully connected.
	ID_NEW_INCOMING_CONNECTION,
	/// RakPeer - The system we attempted to connect to is not accepting new connections.
	ID_NO_FREE_INCOMING_CONNECTIONS,
	/// RakPeer - The system specified in Packet::systemAddress has disconnected from us.  For the client, this would mean the
	/// server has shutdown. 
	ID_DISCONNECTION_NOTIFICATION,
	/// RakPeer - Reliable packets cannot be delivered to the system specified in Packet::systemAddress.  The connection to that
	/// system has been closed. 
	ID_CONNECTION_LOST,
	/// RakPeer - We are banned from the system we attempted to connect to.
	ID_CONNECTION_BANNED,
	/// RakPeer - The remote system is using a password and has refused our connection because we did not set the correct password.
	ID_INVALID_PASSWORD,

	PT_ENTER_GAME_REQUEST = 140,

	PT_ENTER_GAME_ACCEPT = 141,

	PT_HOST_MESSAGE = 180,

	PT_USER_INGAME_MSG = 255,
};

enum host_msg
{
    PT_HOST_READY_REQUEST = 6,
    PT_HOST_USER_READY,				///<有人准备
	PT_HOST_READY_ACCEPT,			///<准备成功
	PT_HOST_GAME_START,				///<游戏开始

    PT_MJ_OPT_FAIL = 72,				
	
	PT_MJ_DAPAI_REQ,
	PT_MJ_USER_DAPAI,
	
	PT_MJ_DASAIZAI_START,
	PT_MJ_DASAIZI_REQ,
	PT_MJ_USER_DASAIZI,
	
	
	PT_MJ_DASAIZI_AG_REQ,
	PT_MJ_USER_DASAIZI_AG,
	
	PT_MJ_GANG_REQ,
	PT_MJ_GANG_PASS_REQ,
	PT_MJ_USER_GANG,
	
	PT_MJ_PENG_REQ,
	PT_MJ_PENG_PASS_REQ,
	PT_MJ_USER_PENG,
	
	PT_MJ_HU_REQ,
	PT_MJ_USER_HU,
	
	PT_MJ_MOPAI_REQ,
	PT_MJ_USER_MOPAI,//89
	
	PT_MJ_MATCH_ACCEPT,
	
	PT_MJ_GAME_START,
	
	PT_MJ_ZHUOZHUANG_REQ,	//<92
	PT_MJ_USER_ZHUOZHUANG,
	
	PT_MJ_LAZHUANG_REQ,
	PT_MJ_USER_LAZHUANG,
	
	PT_MJ_FAPAI,

	PT_MJ_WAIT_USER_OPT,
	PT_MJ_END_GAME,

    //=====ddz================

    PT_DDZ_CHUPAI = 200,
    PT_DDZ_JIAOFEN,
    PT_DDZ_PASS,

    PT_DDZ_USER_CHUPAI,
    PT_DDZ_USER_JIAOFEN,
    PT_DDZ_USER_PASS,

    PT_DDZ_GAME_START,
    PT_DDZ_DZPAI,

    PT_DDZ_USER_JIAOPAI,
    PT_DDZ_GAME_END,

    PT_DDZ_BALANCE,

    PT_DDZ_MATCH_ACCEPT,
};
class CServerInfo
{
public static int SERVER_ID=101;//(300-302)
public static int GAME_ID = 2;
public static int m_nUserId = 10000888;
};


[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
public	struct PT_ENTER_GAME_REQUEST_INFO
{
	public	int serverid;
	public	int gameid;
	public	int uid;
	public	Int64 guid;
	
};



[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
public	struct PT_ENTER_GAME_ACCEPT_INFO
{
	public byte id;				///<消息ID

};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
public struct PT_READY_REQUEST_INFO
{

}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_CHUPAI_INFO
{

    public byte id;

    public uint nMsgid;

    public uint uid;
    public int painum;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public int[] pai;

};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_PASS_INFO
{

    public byte id;

    public uint nMsgid;

   
};
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_JIAOFEN_INFO
{

    public byte id;

    public uint nMsgid;

    public int nFen;

};


[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
public struct PT_DDZ_GAME_START_INFO
{
    public byte id;

    public uint msg2id;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public int[] dipai;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
    public int[] pai;

    //地主ID
    public int nActUid;
}
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_USER_JIAOPAI_INFO
{
    public byte id;

    public uint msg2id;

    public uint nUid;
    public uint nNum;

    public uint nActUid;

}
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_DZPAI_INFO
{
    public byte id;

    public uint nMsgid;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public int[] pai;

    public int nJiaoFen;

    public int nUserId;
    public int nActUid;

};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct SPaiInfo
{
    public uint num;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public uint[] pai;
};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_GAME_END_INFO
{
    public byte id;

    public uint nMsgid;

    public int nGameId;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public SPaiInfo[] pai;

};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_USER_PASS_INFO
{
    public byte id;

    public uint nMsgid;

    public int nUid;

    public int nActUid;

};
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_BALANCE_INFO
{
    public byte id;

    public uint nMsgid;

    public int nMultiple;
    public int nScoreType;
    public int nTax;
    public int nBombNum;
    public int nRocketNum;
    public int nSpriteNum;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public int[] nScore;
    bool bWin;

};


[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_USER_CHUPAI_INFO
{
    public byte id;

    public uint nMsgid;

    public int nUid;
    public int nNum;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public int[] nPai;

    public int nActUid;

};
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct SUserIndexInfo
{
    public int uid;
    public int index;
};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_DDZ_MATCH_ACCEPT_INFO
{
    public char id_1;
    public int id_2;

    public int serverid;
    public int gameid;

    public int usernum;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    SUserIndexInfo[] userindex;
};



[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
struct PT_MJ_MATCH_ACCEPT_INFO
{
    public char id_1;
    public int id_2;


    public int serverid;
    public int gameid;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public SUserIndexInfo[] userindex;

};


/*
 * 
 * 数据转换例子
[StructLayout(LayoutKind.Sequential)]
public struct AlarmEvent
{
    [MarshalAs(UnmanagedType.U4)]
    public uint alarmType;
    [MarshalAs(UnmanagedType.U8)]
    public long alarmTime;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public char[] deviceId;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
    public char[] personId;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public char[] personName;
    [MarshalAs(UnmanagedType.U4)]
    public int pointCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public int[] mapId;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public int[] x;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public int[] y;
}

    */
