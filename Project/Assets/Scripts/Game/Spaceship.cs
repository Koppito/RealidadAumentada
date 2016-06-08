using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float speed;
	public float msBetweenShots;
	public float laserSpeed;
	public Projectile projectile;
	public Transform muzzle;
	public Transform muzzle_2;

	float nextShotTime;
	float tilt = 2;

	//pew pew
	public void Shoot() {
		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
			Projectile newProjectile_2 = Instantiate (projectile, muzzle_2.position, muzzle_2.rotation) as Projectile;
			newProjectile.SetSpeed (laserSpeed);
			newProjectile_2.SetSpeed (laserSpeed);
		}
	}

	//Returns spaceship speed
	public float getSpeed() {
		return speed;
	}

	//Returns spaceships tilt
	public float getTilt() {
		return tilt;
	}
}
