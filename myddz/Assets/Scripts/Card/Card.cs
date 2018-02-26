using UnityEngine;
using System.Collections;

/// <summary>
/// 牌类
/// </summary>
public class Card
{
    private readonly string cardName;
    private readonly Weight weight;
    private readonly Suits color;
    private CharacterType belongTo;

    private readonly int id;
    private bool makedSprite;

    public Card(string name, Weight weight, Suits color, CharacterType belongTo, int id)
    {

        makedSprite = false;
        cardName = name;
        this.weight = weight;
        this.color = color;
        this.belongTo = belongTo;
        this.id = id;
    }

    /// <summary>
    /// 返回牌名
    /// </summary>
    public int GetId
    {
        get { return id; }
    }

    /// <summary>
    /// 返回牌名
    /// </summary>
    public string GetCardName
    {
        get { return cardName; }
    }

    /// <summary>
    /// 返回权值
    /// </summary>
    public Weight GetCardWeight
    {
        get { return weight; }
    }

    /// <summary>
    /// 返回花色
    /// </summary>
    public Suits GetCardSuit
    {
        get { return color; }
    }

    /// <summary>
    /// 是否精灵化
    /// </summary>
    public bool isSprite
    {
        set { makedSprite = value; }
        get { return makedSprite; }
    }

    /// <summary>
    /// 牌的归属
    /// </summary>
    public CharacterType Attribution
    {
        set { belongTo = value; }
        get { return belongTo; }
    }

}
