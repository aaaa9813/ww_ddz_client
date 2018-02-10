using UnityEngine;
using System.Collections;

public class table_main : MonoBehaviour
{

		public GameObject mjcardobj;//外部的prefab传入
		// Use this for initialization

		public GameObject mjtable;

	//ui pretable
	public GameObject ui_card;
	//father node
	public GameObject f_ui_node;

	//麻将牌texture
	private Object[] anim;
	//sprite
	private Object[] sprite;

	//poke sprite
	private Object[] poke;
		void Start ()
		{
		///load mj card img
		anim = Resources.LoadAll("img");

		poke = Resources.LoadAll("img/poke_46_59");
		//断点查看, 有sprite, 也有texture
		sprite = Resources.LoadAll("uiimg");
		int len = anim.Length;

	
				for (int k = 0; k < 14; k++) {

						GameObject obj1 = (GameObject)Instantiate (mjcardobj, new Vector3 ((float)0.5 - (k * (float)0.02), 0, (float)0.30), Quaternion.identity);
						obj1.name = string.Format ("mj{0}", k);
						obj1.transform.parent = mjtable.transform;
					
						obj1.transform.position = new Vector3 (20 - (k * (float)0.382), (float)0.5, (float)10);

						obj1.transform.localScale = Vector3.one;
						obj1.AddComponent<CMouseOpt> ();

		
						foreach (Transform child in obj1.transform) {
								Debug.Log (child.name);

								if (child.name != "front") {
										continue;
								}
								//1, Resources 资源目录名,一个字母都不能少,
								//2, 加载的时候去掉扩展名

			
				//Texture tx = Resources.Load (string.Format("img/{0}B", i)) as Texture;
		

		//						child.renderer.material.mainTexture = (Texture)anim[k];
			

			
						}
				}


				for (int k = 0; k < 14; k++) {
			
						GameObject obj1 = (GameObject)Instantiate (mjcardobj, new Vector3 ((float)0.5 - (k * (float)0.02), 0, (float)0.30), Quaternion.identity);
						obj1.name = string.Format ("mj{0}", k);
						obj1.transform.parent = mjtable.transform;
			
						obj1.transform.position = new Vector3 (20 - (k * (float)0.382), (float)0.5, (float)20);
			
						obj1.transform.localScale = Vector3.one;
						obj1.AddComponent<CMouseOpt> ();
						foreach (Transform child in obj1.transform) {
								Debug.Log (child.name);
				
								if (child.name != "front") {
										continue;
								}
								//1, Resources 资源目录名,一个字母都不能少,
								//2, 加载的时候去掉扩展名
							//	Texture tx = Resources.Load ("img/14W") as Texture;
		
			//					child.renderer.material.mainTexture = (Texture)anim[k+14];

			
						
						}
				}
					

		int width = Screen.width;
		int height = Screen.height;
	//	UIRoot root = GameObject.FindObjectOfType<UIRoot>();
	//	if (root != null) {
	//		float s = (float)root.activeHeight / Screen.height;
	//		height =  Mathf.CeilToInt(Screen.height * s);
	//		width = Mathf.CeilToInt(Screen.width * s);
	//		Debug.Log("height = " + height);
	//		Debug.Log("width = " + width);
	//	}

/*

		|
		|
		|
		|
		|
		|
		|(0,0)
	---------------------------------------
		|
		|
		|

*/
		RectTransform frecttransform = f_ui_node.GetComponent<RectTransform>();
		for (int k = 0; k < 30; k++) {
			
			GameObject obj1 = (GameObject)Instantiate (ui_card, new Vector3 ((float)0.5 - (k * (float)0.02), 0, (float)0.30), Quaternion.identity);
			obj1.name = string.Format ("mj{0}", k);
			obj1.transform.parent = f_ui_node.transform;
			
			RectTransform panl_recttransform = f_ui_node.GetComponent<RectTransform>();
			
			//	http://www.xuanyusong.com/archives/3278
			//UGUI研究院之开始学习搭建界面自适应屏幕（一）
			RectTransform rectTransform = obj1.GetComponent<RectTransform>();
			
			rectTransform.position = new Vector3 (16 * k + 50, 150, (float)20);
			
			UnityEngine.UI.Image img = obj1.GetComponent<UnityEngine.UI.Image>();
			img.sprite = (Sprite)poke[k * 2 + 2];
			
			obj1.transform.localScale = Vector3.one;
			
			
			obj1.AddComponent<CMouseOpt> ();
			foreach (Transform child in obj1.transform) {
				Debug.Log (child.name);
				
				if (child.name != "front") {
					continue;
				}
				//1, Resources 资源目录名,一个字母都不能少,
				//2, 加载的时候去掉扩展名
				//	Texture tx = Resources.Load ("img/14W") as Texture;
				
		//		child.renderer.material.mainTexture = (Texture)anim[k];
				
				
				
			}
		}



		//添加到UI上
		for (int k = 0; k < 14; k++) {
			
			GameObject obj1 = (GameObject)Instantiate (mjcardobj, new Vector3 ((float)0.5 - (k * (float)0.02), 0, (float)0.30), Quaternion.identity);
			obj1.name = string.Format ("mj{0}", k);
			obj1.transform.parent = mjtable.transform;
			
			obj1.transform.position = new Vector3 (20 - (k * (float)0.382), (float)0.5, (float)15);
			
			obj1.transform.localScale = Vector3.one;

		
			obj1.AddComponent<CMouseOpt> ();
			foreach (Transform child in obj1.transform) {
				Debug.Log (child.name);
				
				if (child.name != "front") {
					continue;
				}
				//1, Resources 资源目录名,一个字母都不能少,
				//2, 加载的时候去掉扩展名
				//	Texture tx = Resources.Load ("img/14W") as Texture;
				
		//		child.renderer.material.mainTexture = (Texture)anim[k];
				
				
				
			}
		}




				//	obj1.transform.GetChild(1);
				//	mjcard btntst = obj1.GetComponent<mjcard> ();
				//指定当前实例化的GameObject的父控件是谁.
				//objs.transform.parent = 某父GameObject.transform; 
				//将生成的btn指定父控件为canvas
				//		btntst.transform.parent = canvas.transform;
				//	RectTransform rect = btntst.GetComponents<RectTransform>();
				//	btntst.renderer.material.mainTexture = tx;
			

		

		}

	void OnGUI()
	{
		


		}

		void Net_UserDaPai ()
		{
		}

		void Net_UserOpt ()
		{
		}

		void Net_UserGang ()
		{
		}

		void Net_UserHu ()
		{
		}

		void Net_SendPai ()
		{

		}


		// Update is called once per frame
		void Update ()
		{
	
		}
}
