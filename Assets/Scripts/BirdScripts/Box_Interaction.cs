using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box_Interaction : MonoBehaviour {

	// Use this for initialization
	[SerializeField] Transform boxTrap;
	private float box_center_x = 0;
	private float box_center_y = 0;
	private int box_radius = 1;
	private int shadow_disp = -1;
	private int compress = 3;

	private int dist_x, dist_y;
	private float distance = 0f;

	void Start () {
		box_center_x = boxTrap.position.x;
		box_center_y = boxTrap.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (score ());	
	}


	int score(){
		dist_x = this.transform.position.x - box_center_x;
		dist_y = this.transform.position.y - (box_center_y + shadow_disp);
		distance = Mathf.Sqrt (dist_x * dist_x + dist_y * dist_y);
		return Mathf.floor (1 / distance)1;
	}
}
