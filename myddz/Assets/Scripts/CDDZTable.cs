using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class CDDZTable : MonoBehaviour
    {

        /// <summary>
        /// 当前出牌玩家
        /// </summary>
        public int m_nChupaiUserId;


        /// <summary>
        ///当前出的牌数
        /// </summary>
        public int m_nPaiNum;


        /// <summary>
        /// 当前出的牌ＩＤ，最大20张
        /// </summary>
        public int[] m_nPai;

        /// <summary>
        /// 三张底牌
        /// </summary>
        public int[] m_nDipai;


        /// <summary>
        /// 轮到谁操作
        /// </summary>
        public int m_nActId;


        /// <summary>
        /// 地主ＵＩＤ
        /// </summary>
        public int m_nDizhuId;

        /// <summary>
        /// 当前叫分
        /// </summary>
        public int m_nJiaoFen;


        /// <summary>
        /// 需要更新
        /// </summary>
        private bool m_bflash;


        public Dictionary<int, Card> m_Cardlist;

        /// <summary>
        /// 扑克牌，从预制件生成
        /// </summary>
        public Dictionary<int, GameObject> m_Pokerlist;

        public Dictionary<int, CUser> m_UserlistById;

        CardSprite m_Sprite;

 

        public void Start()
        {
            m_nPai = null;

            m_nDipai = new int[3];

            m_nPaiNum = 0;

            m_nChupaiUserId = -1;


            m_UserlistById = new Dictionary<int, CUser>();
            m_Cardlist = new Dictionary<int, Card>();
            m_Pokerlist = new Dictionary<int, GameObject>();
            m_bflash = false;
            m_Sprite = null;
            int i = 0;

            GameObject pokeobj, poker;
            //创建普通扑克
            for (int color = 0; color < 4; color++)
            {
                for (int value = 0; value < 13; value++)
                {
                    i++;
                    Weight w = (Weight)value;
                    Suits s = (Suits)color;
                    string name = string.Format("Poke_{0}_{1}", color, value);
                    Card card = new Card(name, w, s, CharacterType.Desk, (value + 2) % 13 + 1 + color * 13);
                    m_Cardlist[card.GetId] = card;

                    pokeobj = Resources.Load<GameObject>(string.Format("poke_prefab/Poke_{0}_{1}", (int)card.GetCardSuit, (int)card.GetCardWeight)) as GameObject;
                    poker = Instantiate(pokeobj);

                    m_Sprite = poker.AddComponent<CardSprite>();
                    m_Sprite.Poker = card;

                    m_Pokerlist[card.GetId] = poker;
                }
            }
            Card smallJoker = new Card("Poke_4_13", Weight.SJoker, Suits.None, CharacterType.Desk, 53);
            Card largeJoker = new Card("Poke_4_14", Weight.LJoker, Suits.None, CharacterType.Desk, 54);
            m_Cardlist[smallJoker.GetId] = smallJoker;
            m_Cardlist[largeJoker.GetId] = largeJoker;

            pokeobj = Resources.Load<GameObject>(string.Format("poke_prefab/Poke_{0}_{1}", (int)smallJoker.GetCardSuit, (int)smallJoker.GetCardWeight)) as GameObject;
            poker = Instantiate(pokeobj);

            m_Sprite = poker.AddComponent<CardSprite>();
            m_Sprite.Poker = smallJoker;

            m_Pokerlist[smallJoker.GetId] = poker;



            pokeobj = Resources.Load<GameObject>(string.Format("poke_prefab/Poke_{0}_{1}", (int)largeJoker.GetCardSuit, (int)largeJoker.GetCardWeight)) as GameObject;
            poker = Instantiate(pokeobj);

            m_Sprite = poker.AddComponent<CardSprite>();
            m_Sprite.Poker = largeJoker;
            m_Pokerlist[largeJoker.GetId] = poker;
        }

        public void ClearTable()
        {
            if (m_nPaiNum > 0)
            {
                for (int i = 0; i < m_nPaiNum; i++)
                {
                    m_Pokerlist[m_nPai[i]].SetActive(false);
                }
            }
        }

        public void SetTablePai(int[] pai, int num)
        {

            ClearTable();
            //保存当前出的牌，以便清除
            m_nPaiNum = num;
            m_nPai = pai;

            //m_bflash = true;
            //m_nPai = pai;
            //m_nPaiNum = num;

            //DeskCardsCache.Instance.Clear();
            //for (int i = 0; i < m_nPaiNum; i++)
            //{
            //    DeskCardsCache.Instance.AddCard(m_Cardlist[i]);
            //}

            List<CardSprite> selectedSpriteList = new List<CardSprite>();

            GameObject deskobj = GameObject.Find("Desk");
            Transform desktf = deskobj.transform;

            for (int i = 0; i < num; i++)
            {
                if (!m_Pokerlist.ContainsKey(pai[i]))
                {
                    Debug.LogError(string.Format("SetTablePai, pai id:[{0}] is error", pai[i]));
                    continue;
                }
                CardSprite cp = m_Pokerlist[pai[i]].GetComponent<CardSprite>();

                cp.transform.SetParent(desktf);
                m_Pokerlist[pai[i]].SetActive(true);
                cp.GoToPosition(deskobj, i);
            }



        }

        //private void Update()
        //{
        //    if (!m_bflash)
        //        return;


        //    m_bflash = true;
        //}

        //private static CTable m_this = null;
        //public static CTable Instance()
        //{
        //    if (m_this == null)
        //    {
        //        m_this = new CTable();
        //    }

        //    return m_this;
        //}
    }


}
