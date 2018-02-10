using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_drag : MonoBehaviour, IDragHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDrag (PointerEventData eventData)
	{
		Debug.Log("===ondrag====");
	}
}
