using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour 
{
	public float velocity;
	Rigidbody rb;
	public float dmg;
	public bool laserSpecial;




	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		if (rb != null) {
			rb.velocity = transform.forward * velocity;
		}
		if (!laserSpecial) {
			Destroy (this.gameObject, 4f);
		} 
	}


}
