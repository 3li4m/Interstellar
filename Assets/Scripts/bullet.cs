using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour 
{
	public float velocity;
	Rigidbody rb;
	public int dmg;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		rb.velocity = transform.forward * velocity;
		Destroy(this.gameObject,4f);
	}
}
