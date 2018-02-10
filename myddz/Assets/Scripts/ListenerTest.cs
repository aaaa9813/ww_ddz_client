using UnityEngine;  
using System.Collections;  
using UnityEngine.UI;  
/// <summary>  
/// 脚本位置:UGUI的按钮身上  
/// 脚本功能:动态的添加按钮的点击事件  
/// </summary>  
public class ListenerTest : MonoBehaviour {  
	
	private Button button ;  
	
	void Start () {  
		button = GetComponent<Button>();  
		
		
		button.onClick.AddListener(  
		                           delegate() {  
//			TestButtonClick testClick = GameObject.FindObjectOfType<TestButtonClick>();  
			this.OnClickButton();  
		}  
		);  
	
			
		
	} 

	void OnClickButton()
	{
		Debug.Log ("==112==");
	}
	
	
}  