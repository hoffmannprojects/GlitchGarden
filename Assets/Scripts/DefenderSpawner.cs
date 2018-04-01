using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start () {
		// Check if Defenders game object exists. If not, create it.
		defenderParent = GameObject.Find ("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject ("Defenders");
		}
		// Check for StarDisplay game object.
		starDisplay = GameObject.FindObjectOfType <StarDisplay> ();
		if (!starDisplay) {
			Debug.LogError ("No StarDisplay object found.");
		}
	}

	void OnMouseDown () {
		// Calculate rounded position from clicked position.
		Vector2 rawPosistion = CalculateWorldPointOfClick ();
		Vector2 snappedPosition = SnapToWorldGrid (rawPosistion);
		// Get currently selected defender type.
		GameObject defender = Button.selectedDefender;
		// Get currently selected defender type's price.
		int defenderPrice = defender.GetComponent <Defender> ().price;

		// If a defender type is selected:
		if (Button.selectedDefender) {
			// If enough star credit available:
			if (starDisplay.UseStars (defenderPrice) == StarDisplay.Status.SUCCESS) {
				SpawnDefender (defender, snappedPosition);
			} else {
				// If not enough star credit available:
				Debug.Log ("Insufficient stars.");
			}
		}
	}

	void SpawnDefender (GameObject obj, Vector2 position) {
		GameObject newDefender = Instantiate (obj, position, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}

/*	public void UseStars (int amount) {
		starDisplay.UseStars (amount);
	}*/

	Vector2 SnapToWorldGrid (Vector2 rawWorldPosition) {
		int roundedX, roundedY;
		roundedX = Mathf.RoundToInt (rawWorldPosition.x);
		roundedY = Mathf.RoundToInt (rawWorldPosition.y);
		return new Vector2 (roundedX, roundedY);
		
	}

	Vector2 CalculateWorldPointOfClick () {
		// Get camera component of first found camera object.
		Camera camera = FindObjectOfType <Camera> (). GetComponent <Camera> ();
		// Calculate world units from mouse position (pixels).
		return camera.ScreenToWorldPoint (Input.mousePosition);
		
	}
}
