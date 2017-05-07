using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour {
	[SerializeField] Animation[] birbList;
	[SerializeField] Animation bigBirb;
	[SerializeField] AnimationClip[] birbAnims;
	[SerializeField] AnimationClip mysteryBirbAnim;
	[SerializeField] Image goat;
	[SerializeField] Sprite goatI;
	[SerializeField] Text name;
	[SerializeField] Text description;
	[SerializeField] Text Count;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < birbList.Length; ++i) {
			birbList [i].clip = mysteryBirbAnim;
		}
	}

	public void changeBirb(int birb) {
		birbList[birb].clip = birbAnims[birb];
	}

	public void changeText(int birb) {
		if (Static_Text.birdcaught[birb] >= 1) {
			bigBirb.clip = birbAnims [birb];
			name.text = Static_Text.birdnames [birb];
			description.text = Static_Text.flavortext [birb];
		} else {
			bigBirb.clip = mysteryBirbAnim;
			name.text = Static_Text.mysteryBirbName;
			description.text = Static_Text.mysteryBirbText;
		}
	}

}
