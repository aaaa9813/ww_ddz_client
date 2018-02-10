using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_select : MonoBehaviour, ISelectHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSelect (BaseEventData eventData)
	{
		Debug.Log ("====on select====");
	}

}
