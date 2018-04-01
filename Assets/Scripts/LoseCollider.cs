using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {


	private LevelManager levelmanager;

	void Start () {
		levelmanager = GameObject.FindObjectOfType <LevelManager> ();
		if (!levelmanager) {
			Debug.LogError ("No LevelManager found.");
		}
	}

	void OnTriggerEnter2D () {
		levelmanager.LoadLevel ("03b Lose");
	}
}
