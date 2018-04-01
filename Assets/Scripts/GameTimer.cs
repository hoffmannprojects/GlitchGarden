using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	[Tooltip ("Level time in seconds.")]
	public float levelTime;
	public AudioClip winSound;

	private bool levelIsComplete = false;
	private Slider slider;
	private LevelManager levelManager;
	private Canvas canvas;
	private GameObject levelCompleteMessage;

	// Use this for initialization
	void Start () {
		slider		 		 = GetComponent 	<Slider>();
		if (!slider) 			   { Debug.LogError ("No Slider found."); }

		levelManager 		 = FindObjectOfType <LevelManager> ();
		if (!levelManager) 		   { Debug.LogError ("No Level Manager found."); }

		canvas 		 		 = FindObjectOfType <Canvas> ();
		if (!canvas)			   { Debug.LogError ("No Canvas found."); } 

		levelCompleteMessage = GameObject.Find ("Level Complete");
		if (!levelCompleteMessage) { Debug.LogError ("No Level Complete found."); } 

		levelCompleteMessage.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelTime;

		// If time is over and level is not yet complete:
		if (Time.timeSinceLevelLoad >= levelTime && !levelIsComplete) {
			levelIsComplete = true;

            DestroyAllTaggedObjects();

            AudioSource.PlayClipAtPoint (winSound, transform.position, 0.2f);

			levelCompleteMessage.SetActive (true);

			Invoke ("LoadNextLevel", winSound.length);
		}


	}
	
	// Destroys all objects with destroyOnWin tag
	void DestroyAllTaggedObjects () {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag ("destroyOnWin");
		foreach (GameObject obj in taggedObjects) {
            Destroy(obj);
        }
    }

	void LoadNextLevel ()
	{
		levelManager.LoadNextLevel ();
	}
}
