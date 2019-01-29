using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public int lives;
	public Movement died;
	public GameObject playerControls;
	public GameObject playerGraphics;

	public GameObject waveControls;

	public UI gameOver;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (died.dead && lives > 0) 
		{
			Invoke ("respawn", 2f);
			died.canDie = false;	
			playerControls.gameObject.transform.position = Vector3.Lerp(transform.position,new Vector3 (0, 0, 0),1f);
		} 
		else if(died.dead && lives <= 0) 
		{
			died.canDie = false;	
			playerControls.gameObject.transform.position = Vector3.Lerp(transform.position,new Vector3 (0, 0, 0),1f);
			gameOver.gameOver = true;
			print ("Game Over");
		}
	}

	void respawn()
	{
		died.dead = false;
		died.controlable = true;
		died.canFire = true;
		waveControls.GetComponent<Waves> ().spawnWave = true;
		playerGraphics.SetActive (true);
		Invoke ("killable", 4f);
	}

	void killable()
	{
		died.canDie = true;	
	}
}
