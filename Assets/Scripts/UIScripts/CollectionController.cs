using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour {
	[SerializeField] Animator[] birbList;
	[SerializeField] Animator bigBirb;
	[SerializeField] RuntimeAnimatorController[] birbAnims;
	[SerializeField] RuntimeAnimatorController mysteryBirbAnim;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < birbList.Length; ++i) {
			birbList [i].runtimeAnimatorController = mysteryBirbAnim;
			birbList [i].SetInteger ("States", 3);
		}
	}

	void changeBirb(int birb) {
		birbList[birb].runtimeAnimatorController = birbAnims[birb];
		birbList [birb].SetInteger ("States", 3);
	}
}
