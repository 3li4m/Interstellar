using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	
	public float speed;
	public float stoppingDist;
	public float retreatDist;

	public Transform Player;

	[Header("Dodge Controls")]
	public bool dodge;
	public int dodgeSpeed;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate()
	{
		transform.LookAt (Player);
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
			transform.position = Vector3.Lerp(transform.position, 
				new Vector3(transform.position.x, transform.position.y, transform.position.z + dodgeSpeed * Time.deltaTime), dodgeSpeed);
			Invoke ("stopDodge",.5f);
		}
	}
	void stopDodge()
	{
		dodge = false;
	}
}
