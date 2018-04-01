using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {

    private Animator animator;
	
	void Start () {
        animator = GetComponent<Animator>();
        if (!animator) { Debug.LogError ("No Animator component found."); }
    }

	void OnTriggerStay2D (Collider2D other) {
		// If colliding with an attacker:
		if (other.gameObject.GetComponent<Attacker>()) {
			animator.SetTrigger ("underAttack trigger");
		} 
		
		
	}
}
