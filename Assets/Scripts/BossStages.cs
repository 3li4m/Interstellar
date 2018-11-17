using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStages : MonoBehaviour 
{
	public Enemy enemy;

	public GameObject[] stages;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (enemy.health < enemy.startingHp / 100 * 70) {
			print("health working");
			stages [0].SetActive (false);
			stages [1].SetActive (true);
			stages [2].SetActive (false);
			stages [3].SetActive (false);
		} 
		if (enemy.health < enemy.startingHp / 100 * 45) {
			stages [0].SetActive(false);
			stages [1].SetActive(false);
			stages [2].SetActive(true);
			stages [3].SetActive(false);
		}

		if (enemy.health < enemy.startingHp / 100 * 25) {
			stages [0].SetActive(false);
			stages [1].SetActive(false);
			stages [2].SetActive(false);
			stages [3].SetActive(true);
		}

	}
}
