using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour {
	public GameObject shockWaveParticle;
	public GameObject teleportParticle;
	public GameObject player;
	public GameObject pGraphics;

	public CamShake cam;
	public float speed;

	void Start () {
		speed = player.gameObject.GetComponent<Movement> ().movementSpeed;
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CamShake>();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			player.gameObject.GetComponent<Movement> ().canDie = false;
			Teleport ();
			Invoke ("Display", .5f);
		}
	}
	void Teleport()
	{
		player.gameObject.GetComponent<Movement> ().movementSpeed = 0f;
		pGraphics.GetComponent<Renderer>().enabled = false;

		Instantiate (teleportParticle, this.gameObject.transform.position, teleportParticle.transform.rotation);
		this.gameObject.transform.position = new Vector3(Random.Range(-45,45), 0 ,Random.Range(45,-20));
	}
	void Display()
	{
		player.gameObject.GetComponent<Movement> ().canDie = false;
		player.gameObject.GetComponent<Movement> ().movementSpeed = 0f;
		Invoke ("reEnableMove", 0.5f);
		Instantiate (teleportParticle, this.gameObject.transform.position + new Vector3(0,.5f,0), teleportParticle.transform.rotation);
		Instantiate (shockWaveParticle, this.gameObject.transform.position, shockWaveParticle.transform.rotation);
		cam.GetComponent<CamShake>().shouldShake = true;
		pGraphics.GetComponent<Renderer>().enabled = true;
	}
	void reEnableMove()
	{
		player.gameObject.GetComponent<Movement> ().movementSpeed = speed;
		player.gameObject.GetComponent<Movement> ().canDie = true;
	}
}
