using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_drop : MonoBehaviour, IDropHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log ("===ondrop===");
	}
}
