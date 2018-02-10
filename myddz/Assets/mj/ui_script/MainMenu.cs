
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public GameObject preTabObj;

	//father node
	public GameObject goPanl;

	//poke sprite
	private Object[] poke;



	// Use this for initialization
	void Start () {

		/*
		List<string> btnsName = new List<string>();
		btnsName.Add("BtnPlay");
		btnsName.Add("BtnShop");
		btnsName.Add("BtnLeaderboards");
		foreach(string btnName in btnsName)
		{
			GameObject btnObj = GameObject.Find(btnName);
			Button btn = btnObj.GetComponent<Button>();
			btn.onClick.AddListener(delegate() {
				this.OnClick(btnObj);
			});
		}
		*/

		//load poke
	//	poke = Resources.LoadAll("img/poke");



		poke = Resources.LoadAll<Sprite>("img/poke_63_89");

		RectTransform frecttransform = goPanl.GetComponent<RectTransform>();

		goPanl.AddComponent<Mouse_down>();
		goPanl.AddComponent<Mouse_up>();	


		for (int k = 0; k < 52; k++) {
			
			GameObject obj1 = (GameObject)Instantiate (preTabObj, new Vector3 ((float)0.5 - (k * (float)0.02), 0, (float)0.30), Quaternion.identity);
			obj1.name = string.Format ("mj{0}", k);
			obj1.transform.parent = goPanl.transform;
			
			RectTransform panl_recttransform = goPanl.GetComponent<RectTransform>();
			
			//	http://www.xuanyusong.com/archives/3278
			//UGUI研究院之开始学习搭建界面自适应屏幕（一）
			RectTransform rectTransform = obj1.GetComponent<RectTransform>();
			
			rectTransform.position = new Vector3 (16 * k + 50, 150, (float)20);
			
			UnityEngine.UI.Image img = obj1.GetComponent<UnityEngine.UI.Image>();
			img.sprite = (Sprite)poke[k];
			
			obj1.transform.localScale = Vector3.one;


			Button btn = obj1.GetComponent<Button>();
			btn.onClick.AddListener(delegate() {
				this.OnClick(obj1);
			});

			//添加一个Mousedown.cs脚本到obj1
			obj1.AddComponent<Mouse_down>();
			obj1.AddComponent<Mouse_up>();	
			obj1.AddComponent<Mouse_enter>();

			obj1.AddComponent<Mouse_click>();
			obj1.AddComponent<Mouse_deselect>();	
			obj1.AddComponent<Mouse_drag>();

			obj1.AddComponent<Mouse_drop>();
			obj1.AddComponent<Mouse_exit>();	
			obj1.AddComponent<Mouse_move>();

			obj1.AddComponent<Mouse_scroll>();
			obj1.AddComponent<Mouse_select>();	
			obj1.AddComponent<Mouse_updateselected>();


			
		
		}
	}
	public void OnClick(GameObject sender)
	{
		switch (sender.name)
		{
		case "BtnPlay":
			Debug.Log("BtnPlay");
			break;
		case "BtnShop":
			Debug.Log("BtnShop");
			break;
		case "BtnLeaderboards":
			Debug.Log("BtnLeaderboards");
			break;
		default:
			Debug.Log(sender.name);
			break;
		}
	}
	// Update is called once per frame
	void Update () {
	}
}