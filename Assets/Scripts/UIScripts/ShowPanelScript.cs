using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanelScript : MonoBehaviour {
	[SerializeField] GameObject panelOut;
	[SerializeField] GameObject panelIn;
	[SerializeField] GameObject background;
	[SerializeField] GameObject birbs;
	public float timeToComplete;
	private Vector3 gameBackgroundPosition = new Vector3 (-0.01f, 0, 2);
	public Vector3 gameSkyPosition = new Vector3 (-0.01f, -4.5f, 2f);
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
		} else if (type == "normal" || type == "complete") {
			panel = panelOut;
			otherPanel = panelIn;
		} else {
			panel = panelOut;
			otherPanel = panelIn;
		}
		if (type == "complete") {
			iTween.MoveTo (panel, iTween.Hash ("position", 
				otherPanel.transform.position, "time",
				timeToComplete, "easetype", iTween.EaseType.easeInOutQuad,
				"oncomplete", "scrollDownBackground", "oncompletetarget",
				panelOut));
			Managers.audio.stopAudio (Managers.audio.getAudio (1));
		} else if (type == "normal" || type == "inverse") {
			iTween.MoveTo (panel, iTween.Hash ("position",
				otherPanel.transform.position, "time",
				timeToComplete, "easetype", iTween.EaseType.easeInOutQuad,
				"oncomplete", "moveInPanel", "oncompletetarget",
				panelOut, "oncompleteparams", type));
			if (type == "inverse") {
				Managers.audio.stopAudio (Managers.audio.getAudio (0));
			} else {
				Managers.audio.stopAudio (Managers.audio.getAudio (2));
			}
		}
	}

	public void moveOutPanelGame(string type) {
		GameObject panel;
		GameObject otherPanel;
		if (type == "inverse") {
			// collection to game
			panel = panelIn;
			otherPanel = panelOut;
		} else if (type == "normal" || type == "complete") {
			// normal is game to collection
			// complete is game to title
			panel = panelOut;
			otherPanel = panelIn;
		} else {
			Debug.Log ("else");
			panel = panelOut;
			otherPanel = panelIn;
		}
		if (type == "inverse") {
			iTween.MoveTo (panel, iTween.Hash ("position",
				otherPanel.transform.position, "time",
				timeToComplete, "easetype", iTween.EaseType.easeInOutQuad,
				"oncomplete", "scrollDownBackground", "oncompletetarget",
				panelOut));
		} else if (type == "normal" || type == "complete") {
			iTween.MoveTo (panel, iTween.Hash ("position",
				otherPanel.transform.position, "time",
				timeToComplete, "easetype", iTween.EaseType.easeInOutQuad,
				"oncomplete", "scrollUpBackground", "oncompletetarget",
				panelOut, "oncompleteparams", type));
			if (type == "complete") {
				Managers.audio.stopAudio (Managers.audio.getAudio (0));
			}
		}
		iTween.Pause (birbs, true);
	}

	void scrollUpBackground(string type) {
		if (type == "normal") {
			iTween.MoveTo (background, iTween.Hash ("position",
				gameSkyPosition, "time", timeToComplete, "easetype",
				iTween.EaseType.linear, "islocal", false,
				"oncomplete", "moveInPanel", "oncompletetarget", panelOut, 
				"oncompleteparams", type));
		} else if (type == "complete") {
			iTween.MoveTo(background, iTween.Hash("position",
				gameSkyPosition, "time", timeToComplete, "easetype", 
				iTween.EaseType.linear, "islocal", false,
				"oncomplete", "loadTitleScene", "oncompletetarget",
				panelOut));
		}
	}


	void scrollDownBackground() {
		iTween.MoveTo(background, iTween.Hash("position",
			gameBackgroundPosition, "time", timeToComplete, "easetype",
			iTween.EaseType.linear, "islocal", false,
			"oncomplete", "loadStartScene", "oncompletetarget", panelOut));
	}

	void loadStartScene() {
		Managers.scene.loadScene ("GameScene");
	}

	void loadTitleScene() {
		Managers.scene.loadScene ("TitleScene");
		Static_Text.resetGame ();
	}


	void moveInPanel(string type) {
		GameObject panel;
		Debug.Log (type);
		if (type == "inverse") {
			panel = panelOut;
		} else if (type == "normal" || type == "complete") {
			panel = panelIn;
		} else {
			panel = panelOut;
		}
		Debug.Log (center);
		iTween.MoveTo (panel, iTween.Hash ("position",
			center, "time", timeToComplete, "easetype",
			iTween.EaseType.easeInOutQuad));
		if (birbs != null) {
			iTween.Resume (birbs);
		}
	}

	public void quitGame() {
		Managers.quit.quitApplication ();
	}
}
