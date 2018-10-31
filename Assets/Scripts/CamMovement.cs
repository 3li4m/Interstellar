using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {
	public GameObject targetObj;
	public float rotation = 10f;
	public float smoothness = 1f;


	void Start()
	{
		targetObj = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate () {

		if (targetObj == null) {
			return;
		}

			//this.transform.position = new Vector3 (targetObj.transform.position.x, this.transform.position.y, this.transform.position.z);
			//smoothly move cam to player x coord
			Vector3 smoothPosition = Vector3.Lerp (new Vector3(transform.position.x,transform.position.y,transform.position.z), new Vector3 (targetObj.transform.position.x, this.transform.position.y, this.transform.position.z), smoothness * Time.deltaTime);
			transform.position = smoothPosition;

			//rotate to face player
			Quaternion targetRotation = Quaternion.LookRotation(targetObj.transform.position - transform.position);
			// Smoothly rotate towards the target point.
			Quaternion look = Quaternion.Slerp(transform.rotation, targetRotation, rotation * Time.deltaTime);
			transform.rotation = Quaternion.Euler(look.eulerAngles.x, look.eulerAngles.y, look.eulerAngles.z);
	}
}
