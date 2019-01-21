using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStages : MonoBehaviour 
{
	public Enemy enemy;

	public GameObject[] stages;
	public List<GameObject> debris;
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		BossHpCheck ();
	}

	void OnTriggerStay(Collider other)
	{
		BossHpCheck ();
	}

	void BossHpCheck()
	{
		if (enemy.health < enemy.startingHp / 100 * 70) {
			debris [0].transform.parent = null;
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
		if (enemy.health <= 1) {
			debris [0].transform.parent = this.gameObject.transform;
		}
	}
}
