﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : LivingEntity 
{

	public DealDamage[] objects;

	[Header("Dodge Controls")]
	public bool dodge;
	public int dodgeSpeed;


	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "projectile" || other.gameObject.tag == "Laser") {
			for (int i = 0; i < objects.Length; i++) {
				TakeHit (objects[0].dmg);
			}
			if (other.gameObject.tag == "projectile") {
				Destroy (other.gameObject);
			}
		}
		if (other.gameObject.tag == "shockWave") {
			Die ();
		}
	}
	/*
	void FixedUpdate()
	{
		if (Player == null) {
			return;
		}
		if (!dodge) {
			if (!Player.gameObject.GetComponent<Movement> ().dead) {
				if (Vector3.Distance (transform.position, Player.position) > stoppingDist) {
					transform.position = Vector3.MoveTowards (transform.position, Player.position, speed * Time.deltaTime);
				} else if (Vector3.Distance (transform.position, Player.position) < stoppingDist && Vector3.Distance (transform.position, Player.position) > retreatDist) {
					transform.position = this.transform.position;
				} else if (Vector3.Distance (transform.position, Player.position) < retreatDist) {
					transform.position = Vector3.MoveTowards (transform.position, Player.position, -speed * Time.deltaTime);
				}
			}
		} else {
			transform.Translate(Vector3.left * dodgeSpeed);
			dodge = false;
		}
	}*/
}
