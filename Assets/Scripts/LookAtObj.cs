using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObj : MonoBehaviour {
	public GameObject targetObj;
	public float rotation = 10f;
	public float smoothness = 1f;

	void Start () {
		targetObj = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void FixedUpdate () {
		if (targetObj == null) {
			return;
		}
		if (!targetObj.gameObject.GetComponent<Movement> ().dead) {
			this.transform.LookAt (targetObj.transform);
		}
	}
}
