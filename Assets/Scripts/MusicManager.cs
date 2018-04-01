using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSourceComponent;
	private MusicManager musicManager;
	private int lastLevelMusicWasLoaded = 0;
    private bool volumeIsInitialized = false;

    void Awake () {
		DontDestroyOnLoad(gameObject);
		Debug.Log("Dont destroy on load: " + name); // Name of the gameObject.
	}

	void Start () {
		audioSourceComponent = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded (int Level) {
		// Initialize volume on first load of scene with index 1
        if (Application.loadedLevel == 1 && !volumeIsInitialized) {
            ChangeVolume (PlayerPrefsManager.GetMasterVolume());
            volumeIsInitialized = true;
        }
		
        AudioClip currentLevelMusic = levelMusicChangeArray[Level];

		if (currentLevelMusic) {
			// Only change music if not returning to the level of the music currently playing.
			if (Level != lastLevelMusicWasLoaded) { 
				Debug.Log("Playing clip: " + currentLevelMusic);
				audioSourceComponent.clip = currentLevelMusic;
				audioSourceComponent.loop = true;
				audioSourceComponent.Play();
				lastLevelMusicWasLoaded = Level;
				Debug.Log("Setting last level music was loaded to: " + lastLevelMusicWasLoaded);
			}
			else { Debug.Log("Returning to previous scene (not changing the clip playing)."); }
		}
		else { Debug.LogWarning("No audio clip set for current level."); }
			
	}

	public void ChangeVolume (float volume) {
		audioSourceComponent.volume = volume;
	}

}
	