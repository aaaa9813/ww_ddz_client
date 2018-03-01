using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 交互面板
/// </summary>
using UnityEngine.UI;

public enum GAME_OPT_STATE
{
    GAME_NONE=0,
    GAME_READY,
    GAME_JIAODIZHU,
    GAME_DAPAI,
}

public class CInteractionMgr : MonoBehaviour
{
    private GameObject btnReady;
    private GameObject btnChuPai;
    private GameObject btnBuChu;
    private GameObject btnTiShi;
    private GameObject btn1Fen;
    private GameObject btn2Fen;
    private GameObject btn3Fen;
    private GameObject btnBuQiang;
    private GameController m_Controller;
    // Use this for initialization
    void Start()
    {

        btnReady = gameObject.transform.Find("BtnReady").gameObject;


        btnChuPai = gameObject.transform.Find("BtnChuPai").gameObject;
        btnBuChu = gameObject.transform.Find("BtnBuChu").gameObject;
        btnTiShi = gameObject.transform.Find("BtnTiShi").gameObject;
        
        btn1Fen = gameObject.transform.Find("Btn1Fen").gameObject;
        btn2Fen = gameObject.transform.Find("Btn2Fen").gameObject;
        btn3Fen = gameObject.transform.Find("Btn3Fen").gameObject;

        btnBuQiang = gameObject.transform.Find("BtnBuQiang").gameObject;

        m_Controller = GameObject.Find("GameController").GetComponent<GameController>();

		Button btnTmp = btnReady.GetComponent<Button> ();

		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===准备===");
                this.ReadyCallBack ();
			}
		});

		btnTmp = btnChuPai.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===出牌===");
                this.ChuPaiCallBack ();
			}
		});

		btnTmp = btnBuChu.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===不出===");
                this.BuChuCallBack ();
			}
		});
        btnTmp = btnTiShi.GetComponent<Button>();
        btnTmp.onClick.AddListener(delegate () {
            {
                Debug.Log("===提示===");
                this.TiShiCallBack();
            }
        });

        btnTmp = btn1Fen.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===１分===");
                this.QiangDiZhuCallBack (1);
			}
		});

        btnTmp = btn2Fen.GetComponent<Button>();
        btnTmp.onClick.AddListener(delegate () {
            {
                Debug.Log("===２分===");
                this.QiangDiZhuCallBack(2);
            }
        });

        btnTmp = btn3Fen.GetComponent<Button>();
        btnTmp.onClick.AddListener(delegate () {
            {
                Debug.Log("===３分===");
                this.QiangDiZhuCallBack(3);
            }
        });

        btnTmp = btnBuQiang.GetComponent<Button> ();
		btnTmp.onClick.AddListener (delegate() {
			{
                Debug.Log("===不叫===");
                this.QiangDiZhuCallBack(0);
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
    public void SetGameSate(GAME_OPT_STATE state = GAME_OPT_STATE.GAME_READY)
    {
        switch (state)
        {

            case GAME_OPT_STATE.GAME_NONE:
                {
                    btnReady.SetActive(false);


                    btnChuPai.SetActive(false);
                    btnBuChu.SetActive(false);
                    btnTiShi.SetActive(false);

                    btn1Fen.SetActive(false);
                    btn2Fen.SetActive(false);
                    btn3Fen.SetActive(false);

                    btnBuQiang.SetActive(false);
                }
                break;
            case GAME_OPT_STATE.GAME_DAPAI:
                {

                    btnReady.SetActive(false);


                    btnChuPai.SetActive(true);
                    btnBuChu.SetActive(true);
                    btnTiShi.SetActive(true);

                    btn1Fen.SetActive(false);
                    btn2Fen.SetActive(false);
                    btn3Fen.SetActive(false);

                    btnBuQiang.SetActive(false);
                }
                break;

            case GAME_OPT_STATE.GAME_JIAODIZHU:
                {
                    btnReady.SetActive(false);


                    btnChuPai.SetActive(false);
                    btnBuChu.SetActive(false);
                    btnTiShi.SetActive(false);

                    btn1Fen.SetActive(true);
                    btn2Fen.SetActive(true);
                    btn3Fen.SetActive(true);

                    btnBuQiang.SetActive(true);
                }
                break;
            case GAME_OPT_STATE.GAME_READY:
                {
                    btnReady.SetActive(true);


                    btnChuPai.SetActive(false);
                    btnBuChu.SetActive(false);
                    btnTiShi.SetActive(false);

                    btn1Fen.SetActive(false);
                    btn2Fen.SetActive(false);
                    btn3Fen.SetActive(false);

                    btnBuQiang.SetActive(false);
                }
                break;
        }

    }
    /// <summary>
    /// 激活出牌按钮
    /// </summary>
    /// <param name="canReject"></param>
    void ActiveCardButton(bool canReject)
    {
        btnChuPai.SetActive(true);
        btnBuChu.SetActive(true);

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
        btn1Fen.SetActive(true);
        btnBuQiang.SetActive(true);
        btnReady.SetActive(false);
    }

    public void OnGameStart(PT_DDZ_GAME_START_INFO info1)
    {
        m_Controller.net_XiPai(info1.pai, 17, info1.dipai, 3);

        if (info1.nActUid == CPlayer.Instance().m_nUid)
        {
            SetGameSate(GAME_OPT_STATE.GAME_JIAODIZHU);
        }
        else
        {
            SetGameSate(GAME_OPT_STATE.GAME_NONE);
        }
    }

    /// <summary>
    /// 出牌回调
    /// </summary>
    void ChuPaiCallBack()
    {
        PlayCard playCard = GameObject.Find("Player").GetComponent<PlayCard>();

        int[] pai = new int[20];
        int num;
        if (playCard.CheckSelectCards(pai, out num))
        {
            btnChuPai.SetActive(false);
            btnBuChu.SetActive(false);
        }
        MsgManager m_Msg = GameObject.Find("GameController").GetComponent<MsgManager>();

 
        m_Msg.SendChuPai(pai, num);
        
    }

    /// <summary>
    /// 提示
    /// </summary>
    void TiShiCallBack()
    {

    }

    /// <summary>
    /// 不出
    /// </summary>
    void BuChuCallBack()
    {
        OrderController.Instance.Turn();
        btnChuPai.SetActive(false);
        btnBuChu.SetActive(false);
    }

    /// <summary>
    /// 抢地主
    /// </summary>
    void QiangDiZhuCallBack(int fen)
    {
        //玩家的地主
        //m_Controller.CardsOnTable(CharacterType.Player);
        //OrderController.Instance.Init(CharacterType.Player);
        //btn1Fen.SetActive(false);
        //btnBuQiang.SetActive(false);


        MsgManager m_Msg = GameObject.Find("GameController").GetComponent<MsgManager>();
        m_Msg.SendJiaoFen(fen);
    }

    /// <summary>
    /// 不抢
    /// </summary>
    void BuQiangCallBack()
    {
        int index = Random.Range(2, 4);
        m_Controller.CardsOnTable((CharacterType)index);
        OrderController.Instance.Init((CharacterType)index);
        btn1Fen.SetActive(false);
        btnBuQiang.SetActive(false);
    }

}
