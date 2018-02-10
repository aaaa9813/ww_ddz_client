using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_move : MonoBehaviour, IMoveHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMove (AxisEventData eventData)
	{
		Debug.Log ("===onmove===");
	}
}
