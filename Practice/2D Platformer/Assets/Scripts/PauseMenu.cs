using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	// Use this for initialization
	void Start () {
		PauseUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
