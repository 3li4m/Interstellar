/*
 * Player Controls
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : LivingEntity 
{
	[Header("PlayerControl")]
	public bool controlable;
	public float movementSpeed = 10f;
	public float tilt = 10f;
	Rigidbody rb;
	Transform myT;
	public bool dead;
	public bool canDie = true;

	[Header("WeaponControl")]
	//temp for now put in own script
	public Gun gun;
	public float timeBetweenShots;
	public float shotCounter;
	public bool isFiring;
	public bool canFire;
	//

	[Header("Audio")]
	public AudioSource audioS;
	public AudioSource deathSound;

	[Header("External Objects")]
	public GameObject targetObj;
	public Camera viewCam;

	public Laser laser;

	void Start () 
	{
		dead = false;
		canDie = true;
		canFire = true;
		controlable = true;
		rb = transform.GetComponentInChildren<Rigidbody> ();
		myT = transform;
		audioS = gameObject.GetComponentInChildren<AudioSource> ();
	
	}
	
	void Update()
	{
		gun = gameObject.GetComponentInChildren<Gun>();
		if (controlable) {
			//NEED TO CHANGE WHEN MORE GUNS ARE ADDED MAKE SCRIPT FOR THEM
			if (laser.activeLaser == false) {
				if (Input.GetButton ("Fire1") && canFire == true) {			
					isFiring = true;
					if (isFiring) {
						shotCounter -= Time.deltaTime;
						if (shotCounter <= 0) {
							shotCounter = timeBetweenShots;
							for (int i = 0; i < gun.projectileSpawn.Length; i++) {
								Instantiate (gun.projectile, gun.projectileSpawn[i].position, gun.projectileSpawn [i].rotation);
								//in future make it look for the gun name and swap to coresponding audio source
								audioS.Play();
							}
						}	
					}
				} else {
					shotCounter = 0;
				}
			}
			else{
				return;
			}
		}
	}


	void FixedUpdate () 
	{
		if (controlable) {
			float turn = Input.GetAxis ("Horizontal");
			float move = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (turn, 0, move);
			rb.velocity = movement * movementSpeed;

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
}
