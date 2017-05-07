using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour, IGameManager {
	public ManagerStatus status { get; private set; }

	public void Startup() {
		status = ManagerStatus.Started;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	public void quitApplication() {
		Application.Quit ();
		Debug.Log ("quitted");

	}
}
