using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float speed;

	public void SetSpeed (float newSpeed){
		speed = newSpeed;
	}

	void Update() {
		//Constantly moves forward
		transform.Translate (Vector3.forward * Time.deltaTime * speed);

		//Destroys projectile after certain time
		Destroy (this.gameObject, 1f);
	}

}