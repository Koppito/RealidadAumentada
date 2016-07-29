using UnityEngine;
using System.Collections;

public class EnemyGroup : EnemyController {

	protected int enemiesRemaining;
	protected Enemy[] enemyArray = new Enemy[7];

	private int enemyCount;
	private Vector3 spawnPos;
	private IStrategy strat;
	private Enemy enemyType;

	void Start() {
		enemyType = (Enemy)Resources.Load ("Enemy", typeof(Enemy));
	}

	void Update() {
		if (enemyCount < 2) {
			SpawnEnemies ();
		}

	}

	public void SpawnEnemies() {
		enemyCount += 1;
		spawnPos = new Vector3 (Random.Range(xMin, xMax), 5, zMax);
		for (int x = 0; x < enemyArray.Length; x++) {
			enemyArray [x] = Instantiate (enemyType, spawnPos, Quaternion.Euler(0, 180, 0)) as Enemy;
			enemyArray [x].movementStrategy = enemyArray [x].gameObject.AddComponent<SinStrategy> ();
		}
	}

}
