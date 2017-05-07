using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbDefault : MonoBehaviour {
	[SerializeField] RuntimeAnimatorController mysteryBirb;
	[SerializeField] RuntimeAnimatorController actualBirb;
	private Animator animator;
	public int birbNum;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		animator.runtimeAnimatorController = mysteryBirb as RuntimeAnimatorController;
		animator.SetInteger ("States", 3);
	}

	void changeBirb() {
		animator.runtimeAnimatorController = actualBirb as RuntimeAnimatorController;
		animator.SetInteger ("States", 3);
	}
		

}
