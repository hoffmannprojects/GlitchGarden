using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;


	//private Attacker attacker;

	// Use this for initialization
	void Start () {
		// Needed to make colliders work correctly in unity.
		Rigidbody2D rigidbodyComponent = gameObject.AddComponent<Rigidbody2D> ();
		rigidbodyComponent.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health currentTargetHealth = collider.gameObject.GetComponent<Health> ();

		if (attacker && currentTargetHealth) {
			// Deal damage.
			Debug.Log (name + " dealing " + damage + " damage to " + collider);
			currentTargetHealth.DealDamage (damage);
			Destroy (gameObject);
		} 
	}

}
