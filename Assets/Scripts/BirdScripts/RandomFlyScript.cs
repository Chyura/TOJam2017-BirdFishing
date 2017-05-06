using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlyScript : MonoBehaviour {
	private Vector3[] randomPoints;
	private float currentPathPercent = 0f;
	private int randomMin = 1;
	private int randomMax = 20;
	private Vector3[] screenBounds = new Vector3[4];
	private float birdSpeed = 2f;
	[SerializeField] Transform boxTrap;
	// Use this for initialization
	void Start () {
		
		// this might not take into account the size of the birb
		screenBounds [0] = Camera.main.ScreenToWorldPoint (new Vector3(0, Camera.main.pixelHeight, 0));
		screenBounds [1] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 
			Camera.main.pixelHeight, 0));
		screenBounds [2] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, 0));
		screenBounds [3] = Camera.main.ScreenToWorldPoint (new Vector3(0, 0, 0));
		int numPoints = Random.Range (randomMin, randomMax);
		randomPoints = new Vector3[numPoints];
		for (int i = 0; i < numPoints; ++i) {
			float xValue = Random.Range (screenBounds[0].x, 
										 screenBounds[1].x);
			float yValue = Random.Range (screenBounds [2].y, 
				               			 screenBounds [0].y);
			randomPoints [i] = new Vector3 (xValue, yValue, 0);
		}
		getBoxLanding ();
		moveBirb();
	}

	void moveBirb() {
		iTween.MoveTo(gameObject, iTween.Hash("path", randomPoints, "speed", birdSpeed, 
			"easetype", iTween.EaseType.spring));


	}

	Vector3 getBoxLanding() {
		return Vector3.zero;




	}
}
