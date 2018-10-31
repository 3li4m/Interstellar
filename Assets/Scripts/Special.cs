using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour {

	[Header("GameObjects")]
	public GameObject shockWaveParticle;
	public GameObject teleportParticle;
	public GameObject player;
	public GameObject pGraphics;

	[Header("Camera")]
	public CamShake cam;

	public float speed;

	[Header("UI")]
	public GameObject ui;
	public GameObject cdTxt;

	[Header("Cooldown Settings")]
	public float cooldownTime;
	public float CDTime;
	public float valOverTime;
	public bool cooldown = false; 




	void Start () {
		speed = player.gameObject.GetComponent<Movement> ().movementSpeed;
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CamShake>();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			if (ui.GetComponent<UI> ().sliderVal >= 100) {
				cdTxt.SetActive (true);
				cooldown = true;
				player.gameObject.GetComponent<Movement> ().canDie = false;
				Teleport ();
				cooldownTime = CDTime;
				ui.GetComponent<UI> ().sliderVal = 0;
				Invoke ("Display", .5f);
			}
		}

		if (cooldownTime > 0) {
			cooldownTime -= Time.deltaTime;
			cooldown = true;
		}

		if (cooldownTime <= 0) {
			cooldown = false;
			cdTxt.SetActive (false);
			ui.GetComponent<UI> ().sliderVal += valOverTime * Time.deltaTime;
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
