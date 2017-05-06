using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlyScript : MonoBehaviour {
	private Vector3[] randomPoints;
	//private float currentPathPercent = 0f;
	private int randomMin = 2;
	private int randomMax = 20;
	private Vector3[] screenBounds = new Vector3[4];
	private float birdSpeed = 20f;

	private int upper_bound_percent = 40;

	[SerializeField] Transform boxTrap;
	private float box_center_x = 0;
	private float box_center_y = 0;
	private int box_radius = 1;
	private int shadow_disp = -1;
	private int compress = 3;
	// Use this for initialization
	void Start () {
		
		// this might not take into account the size of the birb
		screenBounds [0] = Camera.main.ScreenToWorldPoint (new Vector3(0, Camera.main.pixelHeight, 0));
		screenBounds [1] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 
			Camera.main.pixelHeight, 0));
		screenBounds [2] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, 0));
		screenBounds [3] = Camera.main.ScreenToWorldPoint (new Vector3(0, 0, 0));
		int numPoints = Random.Range (randomMin, randomMax);
		randomPoints = new Vector3[numPoints+1];
		for (int i = 0; i < numPoints; ++i) {
			float xValue = Random.Range (screenBounds[0].x, 
										 screenBounds[1].x);
			float yValue = Random.Range (screenBounds [2].y, 
				screenBounds [0].y-(screenBounds[0].y-screenBounds [2].y)*(100.0f-upper_bound_percent)/100);
			
			randomPoints [i] = new Vector3 (xValue, yValue, 0);
		}
		randomPoints[numPoints] = getBoxLanding ();
		moveBirb();
	}

	void moveBirb() {
		for (int i = 0; i < randomPoints.Length; i++) {

			Debug.Log (randomPoints[i]);
		}
		iTween.MoveTo(gameObject, iTween.Hash("path", randomPoints, "speed", birdSpeed, 
			"easetype", iTween.EaseType.spring));


	}

	Vector3 getBoxLanding() {
		box_center_x = boxTrap.position.x;
		box_center_y = boxTrap.position.y;
		Debug.Log(box_center_x + " " + box_center_y);
		float xValue = Random.Range (box_center_x - box_radius, box_center_x + box_radius);
		float yValue = Random.Range (box_center_y + shadow_disp - box_radius / compress, 
									box_center_y + shadow_disp + box_radius / compress);
		Debug.Log(xValue + " " + yValue);
		return new Vector3 (xValue, yValue, 0);
	}
}
