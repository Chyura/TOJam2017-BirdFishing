﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbAnimation : MonoBehaviour {

	private Animator animator;


	void Start() {
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
	}
}
