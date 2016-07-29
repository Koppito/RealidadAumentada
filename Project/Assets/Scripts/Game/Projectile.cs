using UnityEngine;
using System.Collections;

public class Projectile : MainController {

	float speed;

	public int Speed{
		set {
			speed = value;
		}
	}

	void Update() {
		//Constantly moves forward
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		transform.Rotate (new Vector3 (0, 0, Time.deltaTime * Random.Range(1000, 10000)), Space.Self);

		//Destroys object once it reaches bounds
		if (this.transform.position.z > zMax) Destroy (this.gameObject);

		if (speed == 0) Debug.Log ("pls set speed to: " + this.gameObject.name);
	}

}