using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//
public class handcard : MonoBehaviour
{

	//public GameObject obj;
	// Use this for initialization
	void Start ()
	{
	
//		GameObject can = GameObject.Find ("Panel");
//		for (int i = 0; i < 20; i++) {
//
//
//			GameObject tt = Instantiate(obj);
//			tt.transform.position = new Vector3(i * 25, 0, 0);
//
//			tt.transform.SetParent(can.transform, false);
//
//			tt.name = "handpoke_" + i;
//
//			Button btn = tt.GetComponent<Button> ();
//
//			btn.onClick.AddListener(  
//				delegate() {  
//					//			TestButtonClick testClick = GameObject.FindObjectOfType<TestButtonClick>();  
//					this.OnClickButton(btn);  
//				}  
//			);  
//		}

		for (int i = 0; i < 20; i++) {

			string name = string.Format ("handpoke_{0}", i);
			GameObject obj = GameObject.Find (name);
			GameObject obj1 = obj.transform.Find ("Button").gameObject;
			Button btn = obj1.GetComponent<Button> ();
			btn.onClick.AddListener (
				delegate() {  
					this.OnClickButton (name, btn);  
				}  
			);  
		}

	}

	void OnClickButton (string name, Button obj)
	{
		Debug.Log (string.Format ("===click name is {0}====", name));
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
