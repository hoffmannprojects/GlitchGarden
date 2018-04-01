using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;

	private GameObject gun, projectileParent;
	private Animator animatorComponent;
	private AttackerSpawner myLaneSpawner;
	private AttackerSpawner[] attackerSpawnerArray;

	void Start () {
		attackerSpawnerArray = FindObjectsOfType <AttackerSpawner>();
		animatorComponent = GetComponent <Animator> ();

		// Creates a Projectiles parent game object if necessary.
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update () {
		if (IsAttackerAheadInLane()) {
			animatorComponent.SetBool ("isAttacking", true);
		} else {
			animatorComponent.SetBool ("isAttacking", false);
		}
	}

	bool IsAttackerAheadInLane () {
		// False if no attackers in lane.
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		// True if attacker with x-position > our x-position exists in lane.	
		foreach (Transform attacker in myLaneSpawner.transform) {	// [?] Is attacker a transform or a game object?
			if (attacker.position.x > transform.position.x) {
				return true;
			}
		}
		// False if attacker in lane, but behind us.
		return false;

	
	}

	// Look through all spawners and set myLaneSpawner if found.
	void SetMyLaneSpawner () {
		foreach (AttackerSpawner attackerSpawner in attackerSpawnerArray) {
			if ( attackerSpawner.transform.position.y == transform.position.y) {
				myLaneSpawner = attackerSpawner;
				return; // Get out if found.
			}
		}

		if (!myLaneSpawner) {
			Debug.LogError (name + ": Could not find the appropriate lane spawner.");
		}
	}

	private void Fire () {
		gun = transform.Find ("Gun").gameObject;
		if (gun) {
			Vector3 position = gun.transform.position;
			GameObject newProjectile = Instantiate (projectile, position, Quaternion.identity) as GameObject;
			newProjectile.transform.parent = projectileParent.transform;
		}  else {Debug.LogError ("No Gun child object found!");
		}
	}
}
