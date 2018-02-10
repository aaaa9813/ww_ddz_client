using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class test : MonoBehaviour {
	
	int i = 0 ;
	float f = 0.0f;
	string msg1 ="";
	/*
	//引用C 、C++中的方法
	[DllImport ("xuanyusong")]
	private static extern int addInt(int a,int b);
	[DllImport ("xuanyusong")]
	private static extern float addFloat(float a,float b);	
	*/

	public delegate int CSCallback(IntPtr data, int len);

	/// <summary>
	/// 这个属性很重要, 不要的话IOS报错, 回调方法都要加
	/// </summary>
	/// <returns>The callback function.</returns>
	/// <param name="msg">Message.</param>
	[AOT.MonoPInvokeCallbackAttribute(typeof(CSCallback))]
	int CSCallbackFunction(IntPtr data, int len)
	{
	//	GUILayout.Label ("=====" + msg);
		//msg1 = msg;
	
		byte[] bt = new byte[len]; 
		Marshal.Copy( ( IntPtr ) data , bt , 0 , len ); 
		return 2;
	}
	CSCallback callback;


	[DllImport ("RakNet")]
	private static extern int Connect(string host, int remotePort, string passwordData, int passwordDataLength);



	[DllImport ("RakNet")]
	extern static int RegMsg(int msgid, CSCallback callback);


	void Start ()
	{
		callback = CSCallbackFunction;
		//调用方法中相加函数
		//i = addInt (1,111);


		//f = addFloat (100f,2.2f);

		i = 100;
		f = 111;

		i = Connect ("127.0.0.1", (int)61010, "", 0);

		i = RegMsg (3, callback);
		
	}
	
	void OnGUI()
	{
		
		//将相加后的信息显示在屏幕中
		if(i !=0)
			GUILayout.Label(" use  c ww  =" +  i );
		
		if(f !=0.0f)
			GUILayout.Label(" use  cplus ww =" +  f );

		GUILayout.Label("call back =" +  msg1 );
	}
}