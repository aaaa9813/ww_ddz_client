using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Mouse_exit : MonoBehaviour, IPointerExitHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		Debug.Log ("===mouse exit===");
	}
}
