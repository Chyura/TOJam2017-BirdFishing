﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScreen : MonoBehaviour {


	public void loadScene(string sceneName) {
		SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Single);
	}




}
