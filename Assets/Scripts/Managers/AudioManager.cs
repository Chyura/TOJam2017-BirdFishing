using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}
	[SerializeField] AudioSource[] audio;
	// 0 is main
	// 1 is game
	// 2 is ending

	public float audioTime = 50f;

	private AudioSource currentAudio;

	public void Startup() {
		currentAudio = audio [1];
		for (int i = 0; i < audio.Length; ++i) {
			audio [i].volume = 0;
			audio [i].Stop ();
		}
		status = ManagerStatus.Started;
	}

	public AudioSource getAudio(int audioNum) {
		return audio [audioNum];
	}
		
	public void playAudio(AudioSource audio) {
		currentAudio.Stop ();
		audio.Play ();
		currentAudio = audio;
		iTween.AudioTo (gameObject, iTween.Hash ("audiosource",
			audio, "volume", 100, "time", audioTime));
	}

	public void stopAudio(AudioSource audio) {
		iTween.AudioTo (gameObject, iTween.Hash ("audiosource",
			currentAudio, "volume", 0, "time", audioTime, "oncomplete", 
			"playAudio", "oncompletetarget", gameObject,
			"oncompleteparams", audio));
	}
}
