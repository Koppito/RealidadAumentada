using UnityEngine;
using System.Collections;

public class DefaultGun : Gun {

	private float nextShotTime;
	private Projectile bullet1;
	private Projectile bullet2;

	public override void Shoot() {
		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + this.fireCadency / 100;
			bullet1 = Instantiate (bullet, player.muzzleLeft.position, player.muzzleLeft.rotation) as Projectile;
			bullet2 = Instantiate (bullet, player.muzzleRight.position, player.muzzleRight.rotation) as Projectile;
			bullet1.Speed = bullet2.Speed = 100;
		}
		
	}

}
