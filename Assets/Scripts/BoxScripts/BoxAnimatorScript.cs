using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimatorScript : MonoBehaviour {
	private Animator animator;
	private AudioSource audio;



	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!animator.GetBool ("BoxFall")) {
				animator.SetBool ("BoxFall", true);
				audio.Play ();
			} else if (animator.GetBool ("BoxFall")) {
				animator.SetBool ("BoxFall", false);
			}
		}
	}
}
