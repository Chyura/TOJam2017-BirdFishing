using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbAnimation : MonoBehaviour {

	private Animator animator;

	void Start() {
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.F)) {
			animator.SetInteger ("States", 1);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			animator.SetInteger ("States", 2);
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			animator.SetInteger ("States", 0);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			animator.SetBool ("Mirror",false );
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			animator.SetBool ("Mirror", true);
		}
		
	}
}
