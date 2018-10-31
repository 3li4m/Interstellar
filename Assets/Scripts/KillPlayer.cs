using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public Movement playerControl;
	public GameObject controls;
	public GameObject deathParticles;

	void OnCollisionEnter(Collision other)
	{
		if (playerControl.canDie) {
			if (other.gameObject.tag == "Enemy") {
				Instantiate (deathParticles, controls.transform.position, deathParticles.transform.rotation);
				playerControl.shake.shouldShake = true;
				playerControl.dead = true;
				controls.SetActive(false);
			}
		}
	}
}
