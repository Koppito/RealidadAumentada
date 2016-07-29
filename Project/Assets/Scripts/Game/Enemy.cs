using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : EnemyGroup {

	public int velocity;
	public IStrategy movementStrategy;

	private int health = 6;
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
	}

	void Update() {
		movementStrategy.MoveStrategy (this.transform.position, this.rb, this.velocity);

		//Destroys object once it reaches zMin
		if (this.transform.position.z < zMin) {
			Destroy (this.gameObject);
		}
	}
}