using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	public void Startup() {
		status = ManagerStatus.Started;
	}

	public void loadScene(string sceneName) {
		SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Single);
	}
}
