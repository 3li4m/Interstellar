using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour 
{
	public float power = 0.7f;
	public float duration = 1.0f;
	public Transform cam;
	public float damping = 1.0f;//slow down ammount
	public bool shouldShake=false;

	public Vector3 startPos;
	float initalDuration;

	void Start () {
		
		initalDuration = duration;
	}
	
	void Update () {
		startPos.x = cam.localPosition.x;

		if (shouldShake) {
			if (duration > 0) {
				cam.localPosition = startPos + Random.insideUnitSphere * power;
				duration -= Time.deltaTime * damping;
			} else {
				shouldShake = false;
				duration = initalDuration;
				cam.localPosition = startPos;
			}
		}
	}
}
