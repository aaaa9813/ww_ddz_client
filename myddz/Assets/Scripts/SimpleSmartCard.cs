using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleSmartCard : SmartCard
{
    void Start()
    {

		Transform tf = transform.Find ("ComputerNotice");
		computerNotice = tf.gameObject;
        OrderController.Instance.smartCard += AutoDiscardCard;
    }

    /// <summary>
    /// 延迟出牌
    /// </summary>
    /// <param name="isNone"></param>
    /// <returns></returns>
    public override IEnumerator DelayDiscardCard(bool isNone)
    {
        return base.DelayDiscardCard(isNone);
    }

    /// <summary>
    /// 一手牌
    /// </summary>
    /// <returns></returns>
    public override List<Card> FirstCard()
    {
        List<Card> ret = new List<Card>();
        for (int i = 12; i >= 5; i--)
        {
            ret = FindStraight(GetAllCards(null), (int)Weight.Three, i, true);
            if (ret.Count != 0)
                break;
        }
        if (ret.Count == 0)
        {
            for (int i = 0; i < 36; i += 3)
            {
                ret = FindThreeAndTwo(GetAllCards(null), i, true);
                if (ret.Count != 0)
                    break;
            }
        }
        if (ret.Count == 0)
        {
            for (int i = 0; i < 36; i += 3)
            {
                ret = FindThreeAndOne(GetAllCards(null), i, true);
                if (ret.Count != 0)
                    break;
            }
        }

        if (ret.Count == 0)
        {
            for (int i = 0; i < 36; i += 3)
            {
                ret = FindOnlyThree(GetAllCards(null), i, true);
                if (ret.Count != 0)
                    break;
            }
        }

        if (ret.Count == 0)
        {
            for (int i = 0; i < 24; i += 2)
            {
                ret = FindDouble(GetAllCards(null), i, true);
                if (ret.Count != 0)
                    break;
            }
        }

        if (ret.Count == 0)
        {
            ret = FindSingle(GetAllCards(null), (int)Weight.Three, true);
        }

        return ret;
    }
}
