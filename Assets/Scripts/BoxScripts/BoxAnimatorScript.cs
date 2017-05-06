using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimatorScript : MonoBehaviour {
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetBool ("BoxFall", true);
		}
	}
}
