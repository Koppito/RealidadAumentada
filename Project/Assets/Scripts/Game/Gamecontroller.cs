using UnityEngine;
using System.Collections;

public class Gamecontroller : MonoBehaviour {

	public Enemy enemy;
	public Player player;
	public GameObject joystick;
	public GameObject fireButton;

	void Awake() {
		Instantiate (joystick);
		//Instantiate (fireButton);
	}

	void Start() {
		Instantiate (player);
		Instantiate (enemy);
	}
}