using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	[Tooltip ("Minimum time between spawns in seconds.")]
	public float minBetweenSpawns = 0f;

	private float nextPossibleSpawnIn = 0f;

	/* UNITY COURSE Q&A Lesson 162 Suggestion 
	private float spawnTime, spawnTimeMax;


	    void Start () {
		float difficulty = PlayerPrefsManager.GetDifficulty ();
		spawnTimeMax = 25f - difficulty * Random.Range (0f, 5f);
		Invoke ("NewEnemy", Random.Range (0f, 4f)); 
	}
		
	void NewEnemy () {
		// Pick a random prefab from array (Random.Range excludes max value when used with ints).
		int attackerSelection = Random.Range (0, attackerPrefabArray.Length); 

		Vector3 pos = transform.position;
		Quaternion rot = Quaternion.identity;
		GameObject newEnemy = Instantiate (attackerPrefabArray [attackerSelection], pos, rot) as GameObject;
		newEnemy.transform.parent = gameObject.transform;
		SpawnEnemy ();
	}

	void SpawnEnemy() {
		spawnTime = Random.value * spawnTimeMax;
		Invoke ("NewEnemy", spawnTime); 
	}
	*/

	/* UNITY COURSE */
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (IsTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker); 
			}
		}	
	}

	void Spawn (GameObject attackerPrefab) {
		GameObject newAttacker = Instantiate (attackerPrefab, transform.position, Quaternion.identity) as GameObject;
		newAttacker.transform.parent = transform;
	}

	bool IsTimeToSpawn (GameObject attacker) {
		float attackerSpawnRate = attacker.GetComponent<Attacker> ().seenEverySeconds;
		float spawnsPerSecond = 1 / attackerSpawnRate;
		// Normalized probability devided by 5 (The probability per lane is one fifth of the overall probability).
		float probability = spawnsPerSecond * Time.deltaTime / 5; 

		// If spawn rate is faster than time it takes to calculate a frame.
		if (Time.deltaTime > attackerSpawnRate) {
			Debug.LogWarning ("Spawn rate capped by frame rate!");
		} 
			
		if (Random.value < probability && Time.time > nextPossibleSpawnIn) { 
			nextPossibleSpawnIn = Time.time + minBetweenSpawns;
			return true;
		} else { return false;}
	}
	// */
}
