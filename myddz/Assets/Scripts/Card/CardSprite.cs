using UnityEngine;
using System.Collections;
/// <summary>
/// 用于卡片的显示
/// </summary>
using UnityEngine.UI;


public class CardSprite : MonoBehaviour
{
    private Card card;
	public  Button sprite;
    private bool isSelected;
    void Start()
    {
		GameObject obj = transform.Find("Button").gameObject;

		Button btn = obj.GetComponent<Button> ();

    

        btn.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;

        Vector2 v2 = btn.GetComponent<RectTransform>().sizeDelta;

        Debug.Log(string.Format("%s===%f, %f", btn.name, v2.x, v2.y));


        btn.transform.localScale = new Vector3(1,1,1);
        btn.transform.position = new Vector3(0,0,0);
        btn.onClick.AddListener (delegate {
			this.OnClick ();
		});
    }


    /// <summary>
    /// sprite所装载的card
    /// </summary>
    public Card Poker
    {
        set
        {
            card = value;
            card.isSprite = true;
            SetSprite();
        }
        get { return card; }
    }

    /// <summary>
    /// 是否被点击中
    /// </summary>
    public bool Select
    {
        set { isSelected = value; }
        get { return isSelected; }
    }

    /// <summary>
    /// 设置UISprite的显示
    /// </summary>
    void SetSprite()
    {
        if (card.Attribution == CharacterType.Player || card.Attribution == CharacterType.Desk)
        {
			Debug.Log(string.Format("==={0}", card.GetCardName));
        }
        else
        {
           // sprite.spriteName = "SmallCardBack1";
        }
    }

    /// <summary>
    /// 销毁精灵
    /// </summary>
    public void Destroy()
    {

        Debug.Log("Destroy~~~~~~~~");
        //精灵化false
        card.isSprite = false;
        //销毁对象
        Destroy(this.gameObject);
    }

    public void SetActvie(bool flag)
    {
        gameObject.SetActive(flag);
    }

    /// <summary>
    /// 调整位置
    /// </summary>
    public void GoToPosition(GameObject parent, int index)
    {
		transform.SetSiblingIndex (10 + index);
       // sprite.depth = index;
        if (card.Attribution == CharacterType.Player)
        {
            Transform cardpoint = parent.transform.Find("CardsStartPoint");
            transform.localPosition = cardpoint.localPosition + Vector3.right * 25 * index;
            if (isSelected)
            {
                transform.localPosition += Vector3.up * 10;
            }
        }
        else if (card.Attribution == CharacterType.ComputerOne ||
            card.Attribution == CharacterType.ComputerTwo)
        {
            transform.localPosition =
                parent.transform.Find("CardsStartPoint").localPosition + Vector3.up * -25 * index;
        }
        else if (card.Attribution == CharacterType.Desk)
        {
            transform.localPosition =
                parent.transform.Find("PlacePoint").localPosition + Vector3.right * 25 * index;
        }

    }

    /// <summary>
    /// 卡牌点击
    /// </summary>
    public void OnClick()
    {
        if (card.Attribution == CharacterType.Player)
        {
            if (isSelected)
            {
                transform.localPosition -= Vector3.up * 10;
                isSelected = false;
            }
            else
            {
                transform.localPosition += Vector3.up * 10;
                isSelected = true;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(string.Format("Left click on this obj. name is:{0}", this.name));
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(string.Format("Right click on this obj. name is:{0}", this.name));
        }

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log(string.Format("Middle click on this obj. name is:{0}", this.name));
        }
    }
}
