using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Rescale_Script : MonoBehaviour {

	private float apparent_y = 0f;
	private float horizon_scale = 0f;
	private float scale_fact = 1.0f;
	private float unit = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		apparent_y = gameObject.transform.position.y;
		//Debug.Log (apparent_y);
		if (apparent_y < -1){
			scale_fact = Mathf.Sqrt (Mathf.Abs (apparent_y - horizon_scale) / unit);
			transform.localScale = new Vector3(scale_fact, scale_fact, 0);
		//transform.Translate(Vector3.up * Time.deltaTime);
		}
	}
}
