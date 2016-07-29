using UnityEngine;
using System.Collections;

public class SinStrategy : IStrategy {

	private float amplitud = 20;
	private float frecuency = 2;

	public override void MoveStrategy(Vector3 position, Rigidbody rbInstance, float velocity) {
		Vector3 newPos;
		newPos = new Vector3 (amplitud * Mathf.Sin(frecuency * Time.time) + position.x, 5, position.z);

		rbInstance.velocity = new Vector3 (0, 0, -1) * velocity;
		rbInstance.position = newPos;
		rbInstance.rotation = Quaternion.Euler (0, 180, -rbInstance.position.x);
	}

}
