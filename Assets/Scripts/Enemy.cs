using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : LivingEntity 
{

	public bullet projectile;

	public float speed;
	public float stoppingDist;
	public float retreatDist;

	public Transform Player;


	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "projectile") {
			TakeHit (projectile.dmg);
			Destroy (other.gameObject);
		}
		if (other.tag == "shockWave") {
			Die ();
		}
	}

	void FixedUpdate()
	{
		if (Player == null) {
			return;
		}
		if (!Player.gameObject.GetComponent<Movement> ().dead) {
			if (Vector3.Distance (transform.position, Player.position) > stoppingDist) {
				transform.position = Vector3.MoveTowards (transform.position, Player.position, speed * Time.deltaTime);
			} else if (Vector3.Distance (transform.position, Player.position) < stoppingDist && Vector3.Distance (transform.position, Player.position) > retreatDist) {
				transform.position = this.transform.position;
			} else if (Vector3.Distance (transform.position, Player.position) < retreatDist) {
				transform.position = Vector3.MoveTowards (transform.position, Player.position, -speed * Time.deltaTime);
			}
		}
	}
}
