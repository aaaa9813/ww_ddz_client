using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_deselect : MonoBehaviour,IDeselectHandler  {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDeselect (BaseEventData eventData)
	{
		Debug.Log ("===ondeselect===");
	}
}
