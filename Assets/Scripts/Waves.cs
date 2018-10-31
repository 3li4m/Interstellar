using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

	public Wave[] waves;
	public Enemy enemy;
	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingAlive;
	int enemiesRemaningToSpawn;
	float nextSpawnTime;

	public GameObject ui;

	public GameObject player;

	public bool spawnWave;

	public float spawnDist;

	void Start () {

		// get wave ui
		ui = GameObject.FindGameObjectWithTag ("ScreenCanvas");
		player = GameObject.FindGameObjectWithTag ("Player");
		NextWave ();
	}

	void Update () {
		if (player.GetComponent<Movement>().dead) {
			spawnWave = false;
		}
		Vector3 spawnPoint = checkDist (spawnDist);
		if (spawnWave != false) {
			if (enemiesRemaningToSpawn > 0 && Time.time > nextSpawnTime) {
	
				enemiesRemaningToSpawn --;

				nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

				Enemy spawnedEnemy = Instantiate(enemy, checkDist (spawnDist), Quaternion.identity) as Enemy;
				spawnedEnemy.OnDeath += OnEnemyDeath;
			}
		}

	}

	Vector3 checkDist(float spawnDist)
	{
		float dist;

		Vector3 loc = new Vector3 (Random.Range (-45, 45), 0, Random.Range (45, -20));
		dist = Vector3.Distance(player.transform.position, loc);

		while (dist <= spawnDist) {
			loc = new Vector3 (Random.Range (-45, 45), 0, Random.Range (45, -20));
			dist = Vector3.Distance(player.transform.position, loc);
		}

		return loc;
	}

	void OnEnemyDeath()
	{
		print ("Enemy Died");
		enemiesRemainingAlive--;
		if (enemiesRemainingAlive == 0) {
			NextWave ();
		}
	}

	void NextWave(){
		currentWaveNumber++;
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];


			ui.GetComponent<UI> ().wave += 1;

			enemiesRemaningToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemaningToSpawn;
		}
	}

	[System.Serializable]
	public class Wave{
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}
