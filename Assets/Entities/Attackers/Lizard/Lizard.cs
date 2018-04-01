using UnityEngine;
using System.Collections;

// Safety check that a Attacker component exists.
[RequireComponent (typeof (Attacker))]

public class Lizard : MonoBehaviour {

	private Attacker attackerComponent;
	private Animator animatorComponent;

	// Use this for initialization
	void Start () {
		attackerComponent = GetComponent<Attacker> ();
		animatorComponent = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;

		// Check if colliding with anything but a defender.
		if (!obj.GetComponent<Defender>()) {
			return; // Leave the method if not colliding with defender.
		} 
		// (else) Attack.
		animatorComponent.SetBool ("isAttacking", true);
		attackerComponent.Attack (obj);
	}
}

