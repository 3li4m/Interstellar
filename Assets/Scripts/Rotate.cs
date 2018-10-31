using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public bool rotRight;
	public float rotSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rotRight) {
			transform.Rotate (0,0,rotSpeed);
		} else {
			transform.Rotate (0,0,-rotSpeed);

		}
	
	}
}
