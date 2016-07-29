using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	float speed;

	public int Speed{
		set {
			speed = value;
		}
	}

	void Update() {
		//Constantly moves forward
		transform.Translate (Vector3.forward * Time.deltaTime * speed);

		//Destroys projectile after certain time
		Destroy (this.gameObject, 1f);
	}
}
