using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour 
{
	public float velocity;
	Rigidbody rb;
	public int dmg;
	public bool laserSpecial;
	public GameObject[] randWep;
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		if (rb != null) {
			rb.velocity = transform.forward * velocity;
		}
		if (!laserSpecial) {
			Destroy (this.gameObject, 4f);
		} else {
			Invoke ("destroyLaser", 20f);
		}
	}

	void destroyLaser()
	{
		randWep [Random.Range (0, randWep.Length)].SetActive (true);
		Destroy (this.gameObject);
	}
}
