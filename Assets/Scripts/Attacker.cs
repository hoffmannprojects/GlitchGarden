using UnityEngine;
using System.Collections;

// Safety check that a Rigidbody2D component exists.
[RequireComponent (typeof (Rigidbody2D))]

public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances.")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animatorComponent;

	// Use this for initialization
	void Start () {
		// Needed to make colliders work correctly in unity.
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;

		animatorComponent = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		// If no current target present, return to walking.
		if (!currentTarget) {
			animatorComponent.SetBool ("isAttacking", false);
		}
	}
		
	public void Attack (GameObject obj) {
		// Set target for damage.
		currentTarget = obj;
	}

	// Called from the animator.
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}

	// Called from the animator at time of the actual hit.
	public void StrikeCurrentTarget (float damage) {
		
		if (currentTarget) {
			// Deal damage.
			Debug.Log (name + " dealing " + damage + " damage to " + currentTarget);
			Health currentTargetHealth = currentTarget.GetComponent<Health> ();
			if (currentTargetHealth) {
				currentTargetHealth.DealDamage (damage);
			}
		}
	}
}
