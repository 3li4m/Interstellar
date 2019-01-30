using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoffFrequency : MonoBehaviour {
	public GameObject Laser;

	void Start () {
		Laser = GameObject.FindGameObjectWithTag ("Laser");

	}

	void Update () {
		if (Laser.GetComponent<Laser>().activeLaser == false) {
			this.gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = Mathf.Lerp (this.gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency, 10009f, 4*Time.deltaTime);
		}
		if (this.gameObject.GetComponent<AudioLowPassFilter> ().cutoffFrequency > 9000f) {
			this.gameObject.GetComponent<AudioLowPassFilter> ().enabled = false;
		}

	}
}
