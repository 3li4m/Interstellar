using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
	public float destroyTime;
		
	void Update () {
		Destroy (this.gameObject, destroyTime);
	}
}
