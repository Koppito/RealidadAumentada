using UnityEngine;
using System.Collections;

public abstract class IStrategy : MonoBehaviour {
	
	public abstract void MoveStrategy(Vector3 position, Rigidbody rbInstance, float velocity);

}
