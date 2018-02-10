using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_enter : MonoBehaviour,IPointerEnterHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		Debug.Log("===mouse enter====");
	}
}
