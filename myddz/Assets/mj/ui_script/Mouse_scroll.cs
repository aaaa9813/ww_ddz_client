using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_scroll : MonoBehaviour, IScrollHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnScroll (PointerEventData eventData)
	{
		Debug.Log ("===on scroll====");
	}
}
