using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour 
{
	public float velocity;
	Rigidbody rb;
	public float dmg;
	public bool laserSpecial;
	public GameObject[] randWep;
	public ParticleSystem[] emitter;

	public float laserSpecialTimer;
	int rand;

	void Start () {
		rand = Random.Range (0, randWep.Length);
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		if (rb != null) {
			rb.velocity = transform.forward * velocity;
		}
		if (!laserSpecial) {
			Destroy (this.gameObject, 4f);
		} else {
			Invoke ("fadeOut", laserSpecialTimer);
		}
	}
	//turns off emitters
	void fadeOut()
	{
		
		print (rand);
		randWep [rand].SetActive (true);
		Destroy (gameObject, .5f);
		//this.gameObject.SetActive (false);
	}

}
