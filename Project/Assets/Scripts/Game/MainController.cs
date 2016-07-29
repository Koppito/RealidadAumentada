using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	
	protected int score;
	protected int currentRound;
	protected float timeMouseDown;
	protected bool mouseDown;
	protected Player player;
	protected ItemController itemController;
	protected EnemyController enemyController;

	//Boundaries
	protected float xMax, xMin, zMax, zMin;

	void Awake() {
		//Bounds setting
		xMax = 25.0f;
		xMin = -xMax;
		zMax = 60.0f;
		zMin = -30.0f;
	}

	void Start() {
		player = GameObject.Find ("Player").GetComponentInChildren<Player> ();
		score = 0;
		currentRound = 1;
	}

	void Update() {
		
	}

	protected bool RoughlyEqual(float a, float b, float threshhold) {
		return (Mathf.Abs (a - b) < threshhold);
	}

	protected void OnPointerDown() {
		mouseDown = true;
	}

	protected void OnPointerUp() {
		mouseDown = false;
		timeMouseDown = 0;
	}
}
