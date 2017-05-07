using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanelScript : MonoBehaviour {
	[SerializeField] GameObject panelOut;
	[SerializeField] GameObject panelIn;
	[SerializeField] GameObject background;
	[SerializeField] SceneLoadScreen loadScene;
	public float timeToComplete;
	private Vector3 gameBackgroundPosition = new Vector3 (0, 0, 2);
	private Vector3 center;
	// Use this for initialization

	void Start() {
		center = new Vector3 (panelOut.transform.position.x, 
			panelOut.transform.position.y, panelOut.transform.position.z);
	}


	// Update is called once per frame
	public void moveOutPanel(string type) {
		GameObject panel;
		GameObject otherPanel;
		if (type == "inverse") {
			panel = panelIn;
			otherPanel = panelOut;
		} else {
			panel = panelOut;
			otherPanel = panelIn;
		}
		if (type == "complete") {
			iTween.MoveTo (panel, iTween.Hash ("position", 
				otherPanel.transform.position, "time",
				timeToComplete, "easetype", iTween.EaseType.easeInOutQuad,
				"oncomplete", "scrollDownBackground"));
		} else {
			iTween.MoveTo (panel, iTween.Hash ("position",
				otherPanel.transform.position, "time",
				timeToComplete, "easetype", iTween.EaseType.easeInOutQuad,
				"oncomplete", "moveInPanel", "oncompletetarget",
				panelOut, "oncompleteparams", type));
		}
	}


	void scrollDownBackground() {
		iTween.MoveTo(background, iTween.Hash("position",
			gameBackgroundPosition, "time", timeToComplete, "easetype",
			iTween.EaseType.linear, "islocal", true,
			"oncomplete", "loadStartScene"));
	}

	void loadStartScene() {
		Managers.scene.loadScene ("GameScene");
	}


	void moveInPanel(string type) {
		GameObject panel;
		Debug.Log (type);
		if (type == "inverse") {
			panel = panelOut;
		} else {
			panel = panelIn;
		}
		Debug.Log (center);
		iTween.MoveTo (panel, iTween.Hash ("position",
			center, "time", timeToComplete, "easetype",
			iTween.EaseType.easeInOutQuad));
	}
}
