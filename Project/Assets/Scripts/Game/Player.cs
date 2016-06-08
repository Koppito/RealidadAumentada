using UnityEngine;
using System.Collections;

//Boundaries... Limits the players max movement
[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

	public Spaceship spaceship;
	public Boundary boundary;

	float moveHorizontal;
	float moveVertical;
	Rigidbody rb;
	VirtualJoystick joystick;

	void Start () {
		//Initializing variables
		rb = GetComponent<Rigidbody> ();

		//Find joystick
		joystick = GameObject.Find("Joystick").GetComponentInChildren<VirtualJoystick>();

		//Instantiating spaceship
		spaceship = Instantiate(spaceship, this.transform.position, this.transform.rotation) as Spaceship;
		spaceship.transform.parent = this.transform;
	}

	void FixedUpdate() {
		//Detecting platform for movement
		moveHorizontal = joystick.Vertical();
		moveVertical = joystick.Horizontal();
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		//Adding movement
		rb.velocity = movement * spaceship.getSpeed();
		rb.position = new Vector3 (Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), transform.position.y, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -spaceship.getTilt());
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.parent.tag == "Enemy") {
			Destroy (this.gameObject);
		}
	}
}
