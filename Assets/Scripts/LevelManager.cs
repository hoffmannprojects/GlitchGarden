using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public bool autoLoadNextLevel = false;
	public float autoLoadNextLevelAfter = 3f;

	void Start () {
		// Load next scene with delay.
		if (autoLoadNextLevel && autoLoadNextLevelAfter > 0) { 
			Invoke("LoadNextLevel", autoLoadNextLevelAfter); 
		} else {
			Debug.Log ("Auto load next level disabled (only positive values in seconds).");
		}
        //GetComponent<Transform>();
	}

	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel (name);
	}
	
	public void LoadNextLevel () {
		// Load next level (by index as set in build settings)
		Application.LoadLevel (Application.loadedLevel + 1);
		Debug.Log ("Loading next level.");
	}

	public void LoadPreviousLevel () {
		// Load previous level (by index as set in build settings)
		Application.LoadLevel (Application.loadedLevel - 1);
		Debug.Log ("Loading previous level.");
	}
}
