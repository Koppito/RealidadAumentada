using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour {

	public float amplitud;
	public float frecuency;
	public Spaceship spaceship;

	Rigidbody rb;
	float posx;

	void Start () {
		this.gameObject.tag = "Enemy";
		rb = GetComponent<Rigidbody> ();

		//Instantiating spaceship
		spaceship = Instantiate(spaceship, this.transform.position, this.transform.rotation) as Spaceship;
		spaceship.transform.parent = this.transform;
	}

	void Update () {
		posx = Mathf.Sin(transform.position.z * frecuency) * amplitud;
		Vector3 movement = new Vector3 (posx, 0f, -1);
		movement *= spaceship.getSpeed() * Time.deltaTime;
		rb.position +=  movement;
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -spaceship.getTilt());
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Projectile") {
			Destroy (this.gameObject);
		}
	}

}