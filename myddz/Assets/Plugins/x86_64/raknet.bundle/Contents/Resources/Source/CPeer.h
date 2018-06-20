#ifndef CPEER_H_
#define CPEER_H_

#include "RakPeerInterface.h"
#include "MessageIdentifiers.h"
#include "RakNetTypes.h"

#include "NatPunchthroughServer.h"
using namespace RakNet;



/* 
The operating system, must be one of: (Q_OS_x) 

DARWIN   - Darwin OS (synonym for Q_OS_MAC) 
SYMBIAN  - Symbian 
MSDOS    - MS-DOS and Windows 
OS2      - OS/2 
OS2EMX   - XFree86 on OS/2 (not PM) 
WIN32    - Win32 (Windows 2000/XP/Vista/7 and Windows Server 2003/2008) 
WINCE    - WinCE (Windows CE 5.0) 
CYGWIN   - Cygwin 
SOLARIS  - Sun Solaris 
HPUX     - HP-UX 
ULTRIX   - DEC Ultrix 
LINUX    - Linux 
FREEBSD  - FreeBSD 
NETBSD   - NetBSD 
OPENBSD  - OpenBSD 
BSDI     - BSD/OS 
IRIX     - SGI Irix 
OSF      - HP Tru64 UNIX 
SCO      - SCO OpenServer 5 
UNIXWARE - UnixWare 7, Open UNIX 8 
AIX      - AIX 
HURD     - GNU Hurd 
DGUX     - DG/UX 
RELIANT  - Reliant UNIX 
DYNIX    - DYNIX/ptx 
QNX      - QNX 
LYNX     - LynxOS 
BSD4     - Any BSD 4.4 system 
UNIX     - Any UNIX BSD/SYSV system 
*/  

//#if defined(__APPLE__) && (defined(__GNUC__) || defined(__xlC__) || defined(__xlc__))  
//#  define Q_OS_DARWIN  
//#  define Q_OS_BSD4  
//#  ifdef __LP64__  
//#    define Q_OS_DARWIN64  
//#  else  
//#    define Q_OS_DARWIN32  
//#  endif  
//#elif defined(__SYMBIAN32__) || defined(SYMBIAN)  
//#  define Q_OS_SYMBIAN  
//#  define Q_NO_POSIX_SIGNALS  
//#  define QT_NO_GETIFADDRS  
//#elif defined(__CYGWIN__)  
//#  define Q_OS_CYGWIN  
//#elif defined(MSDOS) || defined(_MSDOS)  
//#  define Q_OS_MSDOS  
//#elif defined(__OS2__)  
//#  if defined(__EMX__)  
//#    define Q_OS_OS2EMX  
//#  else  
//#    define Q_OS_OS2  
//#  endif  
//#elif !defined(SAG_COM) && (defined(WIN64) || defined(_WIN64) || defined(__WIN64__))  
//#  define Q_OS_WIN32  
//#  define Q_OS_WIN64  
//#elif !defined(SAG_COM) && (defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(__NT__))  
//#  if defined(WINCE) || defined(_WIN32_WCE)  
//#    define Q_OS_WINCE  
//#  else  
//#    define Q_OS_WIN32  
//#  endif  
//#elif defined(__MWERKS__) && defined(__INTEL__)  
//#  define Q_OS_WIN32  
//#elif defined(__sun) || defined(sun)  
//#  define Q_OS_SOLARIS  
//#elif defined(hpux) || defined(__hpux)  
//#  define Q_OS_HPUX  
//#elif defined(__ultrix) || defined(ultrix)  
//#  define Q_OS_ULTRIX  
//#elif defined(sinix)  
//#  define Q_OS_RELIANT  
//#elif defined(__native_client__)  
//#  define Q_OS_NACL  
//#elif defined(__linux__) || defined(__linux)  
//#  define Q_OS_LINUX  
//#elif defined(__FreeBSD__) || defined(__DragonFly__)  
//#  define Q_OS_FREEBSD  
//#  define Q_OS_BSD4  
//#elif defined(__NetBSD__)  
//#  define Q_OS_NETBSD  
//#  define Q_OS_BSD4  
//#elif defined(__OpenBSD__)  
//#  define Q_OS_OPENBSD  
//#  define Q_OS_BSD4  
//#elif defined(__bsdi__)  
//#  define Q_OS_BSDI  
//#  define Q_OS_BSD4  
//#elif defined(__sgi)  
//#  define Q_OS_IRIX  
//#elif defined(__osf__)  
//#  define Q_OS_OSF  
//#elif defined(_AIX)  
//#  define Q_OS_AIX  
//#elif defined(__Lynx__)  
//#  define Q_OS_LYNX  
//#elif defined(__GNU__)  
//#  define Q_OS_HURD  
//#elif defined(__DGUX__)  
//#  define Q_OS_DGUX  
//#elif defined(__QNXNTO__)  
//#  define Q_OS_QNX  
//#elif defined(_SEQUENT_)  
//#  define Q_OS_DYNIX  
//#elif defined(_SCO_DS) /* SCO OpenServer 5 + GCC */  
//#  define Q_OS_SCO  
//#elif defined(__USLC__) /* all SCO platforms + UDK or OUDK */  
//#  define Q_OS_UNIXWARE  
//#elif defined(__svr4__) && defined(i386) /* Open UNIX 8 + GCC */  
//#  define Q_OS_UNIXWARE  
//#elif defined(__INTEGRITY)  
//#  define Q_OS_INTEGRITY  
//#elif defined(VXWORKS) /* there is no "real" VxWorks define - this has to be set in the mkspec! */  
//#  define Q_OS_VXWORKS  
//#elif defined(__MAKEDEPEND__)
//#else  
//#  error "Qt has not been ported to this OS - talk to qt-bugs@trolltech.com"  
//#endif  
//
//#if defined(Q_OS_WIN32) || defined(Q_OS_WIN64) || defined(Q_OS_WINCE)  
//#  define Q_OS_WIN  
//#endif  
//
//#if defined(Q_OS_DARWIN)  
//#  define Q_OS_MAC /* Q_OS_MAC is mostly for compatibility, but also more clear */  
//#  define Q_OS_MACX /* Q_OS_MACX is only for compatibility.*/  
//#  if defined(Q_OS_DARWIN64)  
//#     define Q_OS_MAC64  
//#  elif defined(Q_OS_DARWIN32)  
//#     define Q_OS_MAC32  
//#  endif  
//#endif
#include "common.h"


enum FeatureSupport
{
	SUPPORTED,
	UNSUPPORTED,
	QUERY
};

struct SampleFramework
{
	virtual ~SampleFramework() {}
	virtual const char * QueryName(void)=0;
	virtual const char * QueryRequirements(void)=0;
	virtual const char * QueryFunction(void)=0;
	virtual void Init(RakNet::RakPeerInterface *rakPeer)=0;
	virtual void ProcessPacket(RakNet::RakPeerInterface *rakPeer, Packet *packet)=0;
	virtual void Shutdown(RakNet::RakPeerInterface *rakPeer)=0;

	FeatureSupport isSupported;
};

struct NatPunchthroughServerFramework : public SampleFramework, public NatPunchthroughServerDebugInterface_Printf
{
public:
	NatPunchthroughServerFramework() {isSupported=SUPPORTED; m_pNPS=0;}
	virtual ~NatPunchthroughServerFramework() {}
	virtual const char * QueryName(void) {return "NatPunchthroughServerFramework";}
	virtual const char * QueryRequirements(void) {return "None";}
	virtual const char * QueryFunction(void) {return "Coordinates NATPunchthroughClient.";}
	virtual void Init(RakNet::RakPeerInterface *rakPeer);
	virtual void ProcessPacket(RakNet::RakPeerInterface *rakPeer, Packet *packet){}
	virtual void Shutdown(RakNet::RakPeerInterface *rakPeer);
private:
	NatPunchthroughServer *m_pNPS;
};

class CPeer {
public:
	//CPeer(unsigned short port, bool server = true);
	CPeer(unsigned short port, bool server = true, char * ip = NULL);
	virtual ~CPeer();


	///����һ������
	///����[in] �������ӵ�����������������
	///����[in] ���ô������˿ں�
	///����[in] ���ô�����������
	///����[in] �����������볤�ȡ�
	///����ֵ��ö��StartupResult
	StartupResult Startup(	unsigned     short     	maxConnections,
		unsigned     short     	port = 0,
		const        char *    	passwordData = NULL,
		int 		passwordDataLength = 0);


	///ʹ��IP��ַ�������Ӷ˿����ӵ�ָ����������
	///����[in] Ҫ����������IP������������
	///����[in] Ҫ���������Ķ˿ڡ�
	///����[in] Ҫ�������������롣
	///����[in] Ҫ�������������볤�ȡ�
	///����ֵ��ö��ConnectionAttemptResult
	virtual ConnectionAttemptResult Connect(const       char *     	host,
		unsigned    short     	remotePort = 0,
		const       char *    	passwordData = NULL,
		int			passwordDataLength = 0);


	///����һ�����ݵ�ָ���������ӵĽ�㣻
	///��һ���ֽ�Ϊ������Ϣ��Ψһ��ʶ��
	///����[in]data����ʾҪ���͵����ݣ�
	///����[in]length����ʾ�������ݵĳ��ȣ�
	///����[in]priority,��ʾ�������ݵ����ȼ����μ����ȼ�������
	///����[in]reliability,��ʾ�������ݵĿɿ��ԣ��μ��ɿ���������
	///����[in]systemIdentifer,�����ߡ�
	///����[in]broadcast ��Ϊtrueʱ��ʾ������Ϣ�����е������ӽ�㡣
	///����ֵ 0 ��ʾ��������. �������ֱ�ʶ������Ϣ.
	virtual uint32_t Send(const		char *                data,
		const     int                   length,
		PacketPriority        priority,
		PacketReliability     reliability,
		const     AddressOrGUID         systemIdentifier,
		bool                  broadcast = false);


	uint32_t Send(const 	RakNet::BitStream		* bitStream,
		PacketPriority    	priority,
		PacketReliability   	reliability,
		const 	AddressOrGUID        systemIdentifier,
		bool	              broadcast);

	/// ����Ϣ���л�ȡһ����Ϣ.
	/// ������һ����Ϣ��ʹ��DeallocatePacket()�����ͷ������Ϣ.
	/// ����ֵ 0 ��ʾû����Ϣ�������򽫷�����Ϣ����ָ��.
	virtual Packet* Receive( void );

	/// ������Receive����������һ����Ϣ�󣬵��ô˺��������ͷ�
	/// ����[in] packet ��Ϣ����ָ��.
	virtual void DeallocatePacket( Packet *packet );

	///��ȡ����ID
	///����[in]p ��ʾ�յ����ݰ���ָ�롣
	///����ֵΪ����ID
	static unsigned char GetPacketIdentifier(RakNet::Packet *p);

	///�Ͽ����Ӻ��������Ӹý����û������յ����û��Ͽ���Ϣ
	void Disconnect();

	///�Ͽ����ӵ��������ϵ�ָ���Ŀͻ���
	///����[in] target��ʾҪ�Ͽ��Ŀͻ�������
	void CloseConnection(const AddressOrGUID target);

public:
	RakNet::RakPeerInterface * m_pPeer;

private:
	// Holds packets
	RakNet::Packet* m_pPacket;

	// GetPacketIdentifier returns this
	unsigned char packetIdentifier;

	///Socket����
	SocketDescriptor socketDescriptors[2];

	SampleFramework* m_pNatPunchServer;
};


///============����ʹ��===========================
#include <map>

///����C#�ص�ָ��ĵ���Լ��__stdcall, ����(��ϢID, ����, ���ݳ���)
typedef int (__stdcall * Func)(int, void *, int, unsigned long long sockindex);


typedef void (__stdcall * Func1)();




std::map<int, Func> m_MsgReglist;


std::map<unsigned long long,AddressOrGUID> m_Socketlist;

///============ֻ��WINDOWSƽ̨��Ҫ========================

#if defined (Q_OS_WIN)


#if defined (EXPORTBUILD)  
# define _DLLExport __declspec (dllexport)  
# else  
# define _DLLExport __declspec (dllimport)  
#endif  


///����һ������
///����[in] �������ӵ�����������������
///����[in] ���ô������˿ں�
///����[in] ���ô�����������
///����[in] �����������볤�ȡ�
extern "C" int _DLLExport Startup(	unsigned     short     	maxConnections,
								  unsigned     short     	port = 0,
								  const        char *    	passwordData = NULL,
								  int 		passwordDataLength = 0);


///ʹ��IP��ַ�������Ӷ˿����ӵ�ָ����������
///����[in] Ҫ����������IP������������
///����[in] Ҫ���������Ķ˿ڡ�
///����[in] Ҫ�������������롣
///����[in] Ҫ�������������볤�ȡ�
///����ֵ��ö��ConnectionAttemptResult
extern "C" int _DLLExport Connect(const char *host,
								  int remotePort,
								  const char *passwordData,
								  int passwordDataLength);  


///����һ�����ݵ�ָ���������ӵĽ�㣻
///��һ���ֽ�Ϊ������Ϣ��Ψһ��ʶ��
///����[in]data����ʾҪ���͵����ݣ�
///����[in]length����ʾ�������ݵĳ��ȣ�
///����[in]priority,��ʾ�������ݵ����ȼ����μ����ȼ�������
///����[in]reliability,��ʾ�������ݵĿɿ��ԣ��μ��ɿ���������
///����[in]systemIdentifer,�����ߡ�
///����[in]broadcast ��Ϊtrueʱ��ʾ������Ϣ�����е������ӽ�㡣
///����ֵ 0 ��ʾ��������. �������ֱ�ʶ������Ϣ.
extern "C" int _DLLExport Send(const		char *                data,
					  const     int                   length,
					  PacketPriority        priority,
					  PacketReliability     reliability,
					  const     AddressOrGUID         systemIdentifier,
					  bool                  broadcast = false);





extern "C" 	int _DLLExport SendEx(int msgid, int msgid2, const char * data, const int len, unsigned long long sockindex);


extern "C" int _DLLExport SendEx_1id(int msgid, const char * data, const int len, unsigned long long sockindex);

/// ����Ϣ���л�ȡһ����Ϣ.
/// ������һ����Ϣ��ʹ��DeallocatePacket()�����ͷ������Ϣ.
/// ����ֵ 0 ��ʾû����Ϣ�������򽫷�����Ϣ����ָ��.
extern "C" _DLLExport Packet *  Receive( void );

/// ������Receive����������һ����Ϣ�󣬵��ô˺��������ͷ�
/// ����[in] packet ��Ϣ����ָ��.
extern "C" void _DLLExport DeallocatePacket( Packet *packet );

///��ȡ����ID
///����[in]p ��ʾ�յ����ݰ���ָ�롣
///����ֵΪ����ID
//static unsigned char GetPacketIdentifier(RakNet::Packet *p);

///�Ͽ����Ӻ��������Ӹý����û������յ����û��Ͽ���Ϣ
extern "C" void _DLLExport Disconnect();

///�Ͽ����ӵ��������ϵ�ָ���Ŀͻ���
///����[in] target��ʾҪ�Ͽ��Ŀͻ�������
extern "C" void _DLLExport CloseConnection(const AddressOrGUID target);



extern "C" _DLLExport void RegMsg(int msgid, Func fun);

extern "C" _DLLExport void RegMsgtst(int msgid);

extern "C" _DLLExport void RegMsgtst1(int msgid, Func1 f);

extern "C" _DLLExport void MsgLoop();

extern "C" _DLLExport int MsgInit();

#endif /* CPEER_H_ */


#endif
