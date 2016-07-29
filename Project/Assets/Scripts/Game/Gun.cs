using UnityEngine;
using System.Collections;

public abstract class Gun : MainController {
	
	public Projectile bullet;
	public float fireCadency;

	public abstract void Shoot ();

}
