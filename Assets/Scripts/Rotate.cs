using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public bool rotRight;
	public float rotSpeed;
	public bool vertical;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (vertical) {
			if (rotRight) {
				transform.Rotate (0, 0, rotSpeed);
			} else {
				transform.Rotate (0, 0, -rotSpeed);
			}
		} else {
			if (rotRight) {
				transform.Rotate (0,rotSpeed,0);
			} else {
				transform.Rotate (0,-rotSpeed,0);
			}
		}
	
	
	}
}
