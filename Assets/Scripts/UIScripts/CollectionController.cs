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
	[SerializeField] Image[] birbImage;
	[SerializeField] Sprite[] birbTakeImage;
	[SerializeField] Image biggerBirb;
	[SerializeField] Sprite mysteryBirb;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < birbImage.Length; ++i) {
			birbImage [i].sprite = mysteryBirb;
		}
		biggerBirb.sprite = mysteryBirb;
	}

	public void changeBirb(int birb) {
		birbImage [birb].sprite = birbTakeImage [birb];
	}

	public void changeText(int birb) {
		Debug.Log (birb + " " + Static_Text.birdcaught[birb]);
		if (Static_Text.birdcaught[birb] >= 1) {
			biggerBirb.sprite = birbTakeImage [birb];
			name.text = Static_Text.birdnames [birb];
			description.text = Static_Text.flavortext [birb];
		} else {
			biggerBirb.sprite = mysteryBirb;
			name.text = Static_Text.mysteryBirbName;
			description.text = Static_Text.mysteryBirbText;
		}
	}

}
