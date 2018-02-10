using UnityEngine;
using System.Collections;

public class Mousetst : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log("Left click on this obj");
		}

		if (Input.GetMouseButtonDown (1)) 
		{
			Debug.Log("Right click on this obj");
		}
		if (Input.GetMouseButtonDown (2)) 
		{
			Debug.Log("Middle click on this obj");
		}
	}
}
