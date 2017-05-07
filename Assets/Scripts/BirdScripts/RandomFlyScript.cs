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
	private float compress = 2.0f;

	private int ran_dir = 0;
	private float ran_x_speed, ran_y_speed;
	private float min_speed = 0.5f;
	private float max_speed = 1f;
	private float flyDelayTime = 1f;
	private float flyConstMultiplier = 5f;

	private Vector3 delta = new Vector3(0,0,0);
	private bool fly = false;
	private bool trap_down = false;
	private int invert = 0;

	private float apparent_y = 0f;
	private float horizon_scale = 0f;
	private float scale_fact = 1.0f;
	private float unit = 10.0f;
	private Animator animator;

	private float currpos_x;
	private float lastpos_x = 0f;
	private int state = 0;
	private Vector3[] func_rand;
	// Use this for initialization
	void Start () {

		animator = this.gameObject.GetComponent<Animator> ();

		screenBounds [0] = Camera.main.ScreenToWorldPoint (new Vector3(0, Camera.main.pixelHeight, 0));
		screenBounds [1] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 
			Camera.main.pixelHeight, 0));
		screenBounds [2] = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, 0));
		screenBounds [3] = Camera.main.ScreenToWorldPoint (new Vector3(0, 0, 0));
		int numPoints = Random.Range (randomMin, randomMax);
		randomPoints = new Vector3[numPoints+1];

		Debug.Log ("numPoints " + numPoints + " array length " + randomPoints.Length);

		randomPoints = randomPointGen (screenBounds [0].x + 1, screenBounds [1].x - 1, screenBounds [2].y + 1, 
			screenBounds [0].y - (screenBounds [0].y - screenBounds [2].y) * (100.0f - upper_bound_percent) / 100, numPoints + 1);

		/*
		for (int i = 0; i < numPoints; ++i) {
			float xValue = Random.Range (screenBounds[0].x, 
										 screenBounds[1].x);
			float yValue = Random.Range (screenBounds [2].y, 
				screenBounds [0].y-(screenBounds[0].y-screenBounds [2].y)*(100.0f-upper_bound_percent)/100);
			
			randomPoints [i] = new Vector3 (xValue, yValue, 0);
		}
		*/
		randomPoints[numPoints] = getBoxLanding ();
		moveBirb();

	}

	Vector3[] randomPointGen(float x1, float x2, float y1, float y2, int length){
		func_rand = new Vector3[length];
		for (int i = 0; i < length; ++i) {
			float xValue = Random.Range (x1, x2);
			float yValue = Random.Range (y1, y2);

			func_rand [i] = new Vector3 (xValue, yValue, 0);
		}
		return func_rand;
	}

	void moveBirb() {

		/*for (int i = 0; i < randomPoints.Length; i++) {

			Debug.Log (randomPoints[i]);
		}*/

		//animator.SetInteger ("States", 0);


		iTween.MoveTo(gameObject, iTween.Hash("path", randomPoints, "speed", birdSpeed, 
			"easetype", iTween.EaseType.linear, "oncomplete", "wanderBirb"));
		//wanderBirb = true;

	}

	void wanderBirb(){

		iTween.MoveTo (gameObject, iTween.Hash ("position", getBoxLanding(),
			"speed", birdSpeed/4, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "wanderBirbRepeatTemp"));
		state = Random.Range(0, 2) * 2 + 0;

	} 

	void wanderBirbRepeatTemp(){
		if (!trap_down) {
			wanderBirb();
		}
	}
	void flyBirb(){
		//change animation
		Debug.Log("completed moveBirb");
		ran_dir = Random.Range(1,2);
		ran_x_speed = min_speed + Random.value * (max_speed - min_speed);
		if (ran_dir == 1) {
			ran_x_speed *= -1;
		}
		ran_dir = Random.Range (-200, 200);
		iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (ran_dir, 100, 0),
			"speed", birdSpeed * flyConstMultiplier, "delay", flyDelayTime, "easetype", iTween.EaseType.easeInQuad));
		delta = new Vector3(ran_x_speed, ran_y_speed, 0);
		fly = true;
		Debug.Log (delta);
		Debug.Log ("fly");
		//set invert conditional
		state = 1;
	}

	void Update(){
		if (!fly) {
			rescaleBird ();
		}
		currpos_x = gameObject.transform.position.x;
		if (currpos_x - lastpos_x > 0) {
			invert = 1;
			//Debug.Log ("Right");
		} else {
			invert = 0;		
			//Debug.Log ("Left");
		}

		animator.SetInteger ("States", state); // state + 3*invert

		lastpos_x = currpos_x; 
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
