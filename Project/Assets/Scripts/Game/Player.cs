using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MainController {

	public float velocity;
	public Transform muzzleLeft;
	public Transform muzzleRight;
	public Gun gun;
	public VirtualJoystick joystick;

	private int health = 6;
	private float tilt = 1;
	private bool allowPlayerMovement;
	private Vector3 playerStartPos;
	private Rigidbody rb;

	public int Health {
		get {
			return health;
		}
		set {
			if ((value >= 0) && (value <= 6)) {
				health = value;
			}
		}
	}

	void Start() {
		rb = GetComponent<Rigidbody> ();
		joystick = GameObject.Find ("Joystick").GetComponentInChildren<VirtualJoystick> ();
		playerStartPos = new Vector3(0, 5, -8);
	}

	void Update() {
		//Initial Movement
		if (!RoughlyEqual (transform.position.z, playerStartPos.z, 0.5f))
			transform.position = Vector3.Lerp (transform.position, playerStartPos, 0.05f);
		else 
			allowPlayerMovement = true;

		//Player Movement
		if (allowPlayerMovement) {
			float moveHorizontal = joystick.Horizontal ();

			rb.velocity = new Vector3 (moveHorizontal, 0, 0) * velocity;
			rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
			rb.position = new Vector3 (Mathf.Clamp (rb.position.x, xMin, xMax), transform.position.y, transform.position.z);
		}

		//Detect Button Press
		if (mouseDown) {
			timeMouseDown += Time.deltaTime;
			gun.Shoot ();
		}
	}



}