using UnityEngine;
using System.Collections;

public class PersistentScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
}
