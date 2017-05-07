using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlyScript : MonoBehaviour {
	private Vector3[] randomPoints;
	//private float currentPathPercent = 0f;
	private int randomMin = 2;
	private int randomMax = 20;
	private Vector3[] screenBounds = new Vector3[4];
	public float birdSpeed = 20f;

	private int upper_bound_percent = 40;

	[SerializeField] Transform boxTrap;
	private float box_center_x = 0;
	private float box_center_y = 0;
	private int box_radius = 1;
	private int shadow_disp = -3;
	private int compress = 3;

	private int ran_dir = 0;
	private float ran_x_speed, ran_y_speed;
	private float min_speed = 0.5f;
	private float max_speed = 1f;

	private Vector3 delta = new Vector3(0,0,0);
	private bool fly = false;

	private float apparent_y = 0f;
	private float horizon_scale = 0f;
	private float scale_fact = 1.0f;
	private float unit = 10.0f;
	// Use this for initialization
	void Start () {
		
		screenBounds [0] = Camera.main.ScreenToWorldPoint (new Vector3(0, Camera.main.pixelHeight, 0));
		screenBounds [1] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 
			Camera.main.pixelHeight, 0));
		screenBounds [2] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, 0));
		screenBounds [3] = Camera.main.ScreenToWorldPoint (new Vector3(0, 0, 0));
		int numPoints = Random.Range (randomMin, randomMax);
		randomPoints = new Vector3[numPoints+1];
		Debug.Log ("numPoints " + numPoints + " array length " + randomPoints.Length);
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
			"easetype", iTween.EaseType.linear, "oncomplete", "flyBirb"));

	}

	void wanderBirb(){
	}
	void flyBirb(){
		//change animation
		Debug.Log("completed moveBirb");
		ran_dir = Random.Range(1,2);
		ran_x_speed = min_speed + Random.value * (max_speed - min_speed);
		if (ran_dir == 1) {
			ran_x_speed *= -1;
		}
		iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (0, 100, 0),
			"speed", birdSpeed, "easetyoe", iTween.EaseType.easeInOutSine));
		delta = new Vector3(ran_x_speed, ran_y_speed, 0);
		fly = true;
		Debug.Log (delta);
		Debug.Log ("fly");
	}

	void Update(){
		//if (fly) {
		//	transform.Translate(delta);
		//}
		rescaleBird ();
	}

	Vector3 getBoxLanding() {
		box_center_x = boxTrap.position.x;
		box_center_y = boxTrap.position.y;
		Debug.Log(box_center_x + " " + box_center_y);
		float xValue = Random.Range (box_center_x - box_radius, box_center_x + box_radius);
		float yValue = Random.Range (box_center_y + shadow_disp - box_radius / compress, 
									box_center_y + shadow_disp + box_radius / compress);
		return new Vector3 (xValue, yValue, 0);
	}

	void rescaleBird() {
		apparent_y = gameObject.transform.position.y;
		//Debug.Log (apparent_y);
		if (apparent_y < -1) {
			scale_fact = Mathf.Sqrt (Mathf.Abs (apparent_y - horizon_scale) / unit);
			transform.localScale = new Vector3 (scale_fact, scale_fact, 0);
			//transform.Translate(Vector3.up * Time.deltaTime);
		}
	}
}
