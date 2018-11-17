using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge : MonoBehaviour {

	public EnemyMovement controls;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "projectile") {
			controls.GetComponent<EnemyMovement> ().dodge = true;
		}
	}
}
