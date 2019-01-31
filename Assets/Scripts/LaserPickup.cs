using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPickup : MonoBehaviour {

	public GameObject laser;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			laser.SetActive (true);
			other.gameObject.GetComponentInChildren<Laser> ().activeLaser = true;
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
