using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Button configGear;
	public Button playCube;
	public GameObject gameTitle;
	public Gamecontroller gameController;

	Ray ray;

	void Start () {
		//Instantiating menu elements
		configGear = Instantiate(configGear) as Button;
		playCube = Instantiate(playCube) as Button;
		gameTitle = Instantiate(gameTitle) as GameObject;

		//Parent to Main Menu
		configGear.transform.parent = this.transform;
		playCube.transform.parent = this.transform;
		gameTitle.transform.parent = this.transform;
	}

	void Update () {
		//Gear rotation
		configGear.transform.RotateAround (configGear.transform.position, Vector3.forward, -1);

		//Button clicked
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (playCube.isClicked (ray)) {
			Destroy (this.gameObject, 0.25f);
			Invoke ("StartGame", 0.24f);
		}
		if (configGear.isClicked (ray)) {
			Destroy (this.gameObject, 0.25f);
			Invoke ("StartConfigMenu", 0.24f);
		}

	}

	void StartGame() {
		Instantiate (gameController);
	}

	void StartConfigMenu() {
		
	}
}