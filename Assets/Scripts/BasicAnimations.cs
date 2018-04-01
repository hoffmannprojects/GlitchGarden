using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BasicAnimations : MonoBehaviour {

	public bool colorFadeOut = false;
	public Color fadeColor;

	public bool canvasGroupFadeIn = false;
	public float startAlpha = 0f;

	public float fadeTime = 2f;

	private Image imageComponent;
	private CanvasGroup canvasGroupComponent;

	// Use this for initialization
	void Start () {
		imageComponent = GetComponent<Image> ();
		canvasGroupComponent = GetComponent<CanvasGroup> ();
	}

	// TUTORIAL
	void Update () {
		
		// Image fadeOut
		if (colorFadeOut == true) {
			if (imageComponent) {
				if (Time.timeSinceLevelLoad < fadeTime) {
					// Fade out.
					imageComponent.color = fadeColor;
					float changePerFrame = Time.deltaTime / fadeTime; // One frame in "fractions of fadeOutTime".
					fadeColor.a -= changePerFrame;
					
				} else {
					gameObject.SetActive (false);
				}
			} else {
				Debug.LogWarning ("No Image component found!");
			}
		}

		// Canvas Group fade out
		if (canvasGroupFadeIn == true) {
			
			if (canvasGroupComponent) {
				
				if (Time.timeSinceLevelLoad < fadeTime) {
					// Fade out.
					canvasGroupComponent.alpha = startAlpha;
					float changePerFrame = Time.deltaTime / fadeTime; // One frame in "fractions of fadeOutTime".
					startAlpha += changePerFrame;
				} 

			} else {
				Debug.LogWarning ("No CanvasGroup component found!");
			}

		}
	}
}
