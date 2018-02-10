using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Mouse_down : MonoBehaviour,IPointerDownHandler {

	bool bDown = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerDown(PointerEventData eventData)
	{
				Vector3 v3 = this.transform.position;

				if (bDown) {

						bDown = false;
						v3.y += 20;
				} else {
						bDown = true;

						v3.y -= 20;
				}
				//	v3.z += 20;

				this.transform.position = v3;
				Debug.Log ("mouse down"+this.name);
		}
}
