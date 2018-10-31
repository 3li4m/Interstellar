using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : LivingEntity 
{
	public float movementSpeed = 10f;
	public float tilt = 10f;
	Rigidbody rb;
	Transform myT;

	public bool canDie = true;

	//temp for now put in own script
	public Transform[] projectileSpawn;
	public GameObject projectile;
	public float timeBetweenShots;
	public float shotCounter;
	public bool isFiring;
	//

	public bool dead;

	public GameObject targetObj;

	public Camera viewCam;

	public AudioSource audioS;

	void Start () 
	{
		dead = false;
		canDie = true;
		rb = transform.GetComponentInChildren<Rigidbody> ();
		myT = transform;
		audioS = gameObject.GetComponentInChildren<AudioSource> ();
	}
	
	void Update()
	{
		//NEED TO CHANGE WHEN MORE GUNS ARE ADDED MAKE SCRIPT FOR THEM
		if (Input.GetButton ("Fire1")) {			
			isFiring = true;
			if (isFiring) {
				shotCounter -= Time.deltaTime;
				if (shotCounter <= 0) {
					shotCounter = timeBetweenShots;
					for (int i = 0; i < projectileSpawn.Length; i++) {
						Instantiate (projectile, projectileSpawn [i].position, projectileSpawn [i].rotation);
						//in future make it look for the gun name and swap to coresponding audio source
						audioS.Play();
					}
				}	
			}
		} else {
			shotCounter = 0;
		}
	}


	void FixedUpdate () 
	{
		float turn = Input.GetAxis ("Horizontal");
		float move = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (turn, 0, move);
		rb.velocity = movement * movementSpeed;
		rb.rotation = Quaternion.Euler (Vector3.forward * turn * tilt);
	
		Ray ray = viewCam.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDist;



		if (groundPlane.Raycast (ray, out rayDist)) 
		{
			Vector3 point = ray.GetPoint (rayDist);
			Vector3 heightCorrectPoint = new Vector3 (point.x, transform.position.y, point.z);

			targetObj.transform.position = heightCorrectPoint;
		}

		Quaternion targetRotation = Quaternion.LookRotation(targetObj.transform.position - transform.position);

		// Smoothly rotate towards the target point.
		Quaternion look = Quaternion.Slerp(transform.rotation, targetRotation, tilt * Time.deltaTime);
		transform.rotation = Quaternion.Euler(look.eulerAngles.x, look.eulerAngles.y, look.eulerAngles.z);
	}
}
