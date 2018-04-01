using UnityEngine;
  using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManger;
	// Use this for initialization
	void Start () {
		// Find the MusicManager that was started on splash screen.
		musicManger = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (musicManger) {
			musicManger.ChangeVolume (volumeSlider.value);
		} else {
			Debug.LogWarning ("No MusicManager object found.");
		}

	}

	public void SaveAndExit () {
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		Debug.Log ("Master volume set to " + PlayerPrefsManager.GetMasterVolume ().ToString ());

		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		Debug.Log ("Difficulty set to " + PlayerPrefsManager.GetDifficulty ().ToString ());

		levelManager.LoadLevel ("01a Start");
	}

	public void SetDefaults () {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
}
