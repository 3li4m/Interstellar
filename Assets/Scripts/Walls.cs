using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	void Start () {
		
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "projectile") {
			Destroy (other.gameObject);
		}
	}

	void Update () {
		
	}
}
