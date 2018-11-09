using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public Movement playerControl;
	public GameObject controls;
	public GameObject deathParticles;
	public Respawn lives;

	void OnCollisionEnter(Collision other)
	{
		if (playerControl.canDie) {
			if (other.gameObject.tag == "Enemy") {
				playerControl.canDie = false;
				lives.lives--;
				controls.SetActive(false);
				Instantiate (deathParticles, controls.transform.position, deathParticles.transform.rotation);
				playerControl.shake.shouldShake = true;
				playerControl.dead = true;
				playerControl.deathSound.Play ();
				playerControl.canFire = false;
				playerControl.controlable = false;
			}
		}
	}
}
