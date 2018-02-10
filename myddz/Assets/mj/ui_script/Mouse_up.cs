using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Mouse_up : MonoBehaviour,IPointerUpHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		Debug.Log ("mouse up");
	}
}
