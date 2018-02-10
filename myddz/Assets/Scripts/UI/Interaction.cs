using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 交互面板
/// </summary>
using UnityEngine.UI;


public class Interaction : MonoBehaviour
{
    private GameObject gbReady;
    private GameObject gbChuPai;
    private GameObject gbBuChu;
    private GameObject gbQiangDiZhu;
    private GameObject gbBuQiang;
    private GameController m_Controller;
    // Use this for initialization
    void Start()
    {

        gbReady = gameObject.transform.Find("BtnReady").gameObject;


        gbChuPai = gameObject.transform.Find("BtnChuPai").gameObject;
        gbBuChu = gameObject.transform.Find("BtnBuChu").gameObject;

        gbQiangDiZhu = gameObject.transform.Find("Btn1Fen").gameObject;
        gbBuQiang = gameObject.transform.Find("BtnBuQiang").gameObject;

        m_Controller = GameObject.Find("GameController").GetComponent<GameController>();

		Button btnTmp = gbReady.GetComponent<Button> ();

		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===发牌===");
                this.ReadyCallBack ();
			}
		});

		btnTmp = gbChuPai.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===发牌2===");
                this.ChuPaiCallBack ();
			}
		});

		btnTmp = gbBuChu.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===发牌3===");
                this.BuChuCallBack ();
			}
		});

		btnTmp = gbQiangDiZhu.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===发牌4===");
                this.QiangDiZhuCallBack ();
			}
		});

		btnTmp = gbBuQiang.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===发牌5===");
                this.BuQiangCallBack ();
			}
		});
		//ww
//        deal.GetComponent<UIButton>().onClick.Add(new EventDelegate(DealCallBack));
//        play.GetComponent<UIButton>().onClick.Add(new EventDelegate(PlayCallBack));
//        disard.GetComponent<UIButton>().onClick.Add(new EventDelegate(DiscardCallBack));
//        grab.GetComponent<UIButton>().onClick.Add(new EventDelegate(GrabLordCallBack));
//        disgrab.GetComponent<UIButton>().onClick.Add(new EventDelegate(DisgrabLordCallBack));

        //激活出牌按钮事件绑定
      OrderController.Instance.activeButton += ActiveCardButton;
//
//        play.SetActive(false);
//        disard.SetActive(false);
//        grab.SetActive(false);
//        disgrab.SetActive(false);
    }

    /// <summary>
    /// 激活出牌按钮
    /// </summary>
    /// <param name="canReject"></param>
    void ActiveCardButton(bool canReject)
    {
        gbChuPai.SetActive(true);
        gbBuChu.SetActive(true);

      //ww  disard.GetComponent<UIButton>().isEnabled = canReject;
    }

    /// <summary>
    /// 发牌回调
    /// </summary>
    public void ReadyCallBack()
    {

        PlayCard playCard = GameObject.Find("Player").GetComponent<PlayCard>();
        playCard.Ready();

     


    }

    public void OnGameStart()
    {
        m_Controller.XiPai();

        //抢地主出现
        gbQiangDiZhu.SetActive(true);
        gbBuQiang.SetActive(true);
        gbReady.SetActive(false);
    }

    /// <summary>
    /// 出牌回调
    /// </summary>
    void ChuPaiCallBack()
    {
        PlayCard playCard = GameObject.Find("Player").GetComponent<PlayCard>();
        if (playCard.CheckSelectCards())
        {
            gbChuPai.SetActive(false);
            gbBuChu.SetActive(false);
        }
    }

    /// <summary>
    /// 不出
    /// </summary>
    void BuChuCallBack()
    {
        OrderController.Instance.Turn();
        gbChuPai.SetActive(false);
        gbBuChu.SetActive(false);
    }

    /// <summary>
    /// 抢地主
    /// </summary>
    void QiangDiZhuCallBack()
    {
        //玩家的地主
        m_Controller.CardsOnTable(CharacterType.Player);
        OrderController.Instance.Init(CharacterType.Player);
        gbQiangDiZhu.SetActive(false);
        gbBuQiang.SetActive(false);
    }

    /// <summary>
    /// 不抢
    /// </summary>
    void BuQiangCallBack()
    {
        int index = Random.Range(2, 4);
        m_Controller.CardsOnTable((CharacterType)index);
        OrderController.Instance.Init((CharacterType)index);
        gbQiangDiZhu.SetActive(false);
        gbBuQiang.SetActive(false);
    }

}
