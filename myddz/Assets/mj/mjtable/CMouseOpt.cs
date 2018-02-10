using UnityEngine;
using System.Collections;

public class CMouseOpt : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnMouseOver ()
		{
				if (Input.GetMouseButtonDown (0)) {
						Debug.Log (string.Format ("Left click on this obj. name is:{0}", this.name));
				}
		
				if (Input.GetMouseButtonDown (1)) {
						Debug.Log (string.Format ("Right click on this obj. name is:{0}", this.name));
				}

				if (Input.GetMouseButtonDown (2)) {
						Debug.Log (string.Format ("Middle click on this obj. name is:{0}", this.name));
				}
		}
}

