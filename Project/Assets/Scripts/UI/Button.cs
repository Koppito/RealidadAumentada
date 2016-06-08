using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	Vector3 startScale;

	void Start() {
		startScale = this.transform.localScale;
	}

	//Returns if button is clicked/pressed
	public bool isClicked(Ray ray) {
		RaycastHit hit;
		transform.localScale = startScale;
		if (Input.GetMouseButton (0)) {
			if (Physics.Raycast (ray, out hit) && hit.transform.gameObject == this.gameObject) {
				hit.transform.localScale += new Vector3 (0, 0, -0.25f);
				return true;
			}
		}
		//If all else fails..
		return false;
	}


		
}