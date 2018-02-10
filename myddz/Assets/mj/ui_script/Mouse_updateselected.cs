using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_updateselected : MonoBehaviour, IUpdateSelectedHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnUpdateSelected (BaseEventData eventData)
	{
		Debug.Log ("===on update selected===");
	}

}
