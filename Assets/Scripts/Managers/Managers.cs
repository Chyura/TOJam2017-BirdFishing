using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(LevelManager))]

public class Managers : MonoBehaviour {
	public static AudioManager audio { get; private set; }
	public static LevelManager scene { get; private set; }
	public static Quit quit {get; private set;}

	private List<IGameManager> _startSequence;

	void Awake() {
		audio = GetComponent<AudioManager> ();
		scene = GetComponent<LevelManager> ();
		quit = GetComponent<Quit> ();

		_startSequence = new List<IGameManager> ();
		_startSequence.Add(audio);
		_startSequence.Add (scene);
		_startSequence.Add (quit);

		StartCoroutine (StartupManagers ());
	}

	private IEnumerator StartupManagers() {
		foreach (IGameManager manager in _startSequence) {
			manager.Startup ();
		}
		yield return null;
		int numModules = _startSequence.Count;
		int numReady = 0;

		while (numReady < numModules) {
			int lastReady = numReady;
			numReady = 0;
			foreach (IGameManager manager in _startSequence) {
				if (manager.status == ManagerStatus.Started) {
					numReady++;
				}
			}
			yield return null;
		}
		scene.loadScene ("TitleScene");
		yield return new WaitForSeconds (1f);
		audio.playAudio (audio.getAudio (0));
	}
}
