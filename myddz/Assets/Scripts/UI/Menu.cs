using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// 菜单面板
/// </summary>
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    private GameController controller;
    // Use this for initialization
    void Start()
    {
		GameObject obj = GameObject.Find ("Button12");
		Button btn = obj.GetComponent<Button> ();
		btn.onClick.AddListener(
			delegate()
			{
				this.StartEasyGame();
			}
		);

		//=====================================

		obj = GameObject.Find ("Button");
		btn = obj.GetComponent<Button> ();
		btn.onClick.AddListener(
			delegate()
			{
			this.StartNormalGame();
		}
		);
    //ww    transform.Find("Normal").gameObject.GetComponent<UIButton>().onClick.Add(new EventDelegate(StartNormalGame));
 
		controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    /// <summary>
    /// 选择简单模式
    /// </summary>
   public void StartEasyGame()
    {
		Debug.Log ("==11=");
        controller.InitInteraction();
        controller.InitScene();
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 选择普通模式
    /// </summary>
   public void StartNormalGame()
    {
        //普通场倍数2
        controller.Multiples = 2;
        controller.InitInteraction();
        controller.InitScene();
        Destroy(this.gameObject);
    }
}
