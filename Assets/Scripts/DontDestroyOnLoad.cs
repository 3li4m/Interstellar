using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad(this);

		//find objects with same type and if there is more than one delete it
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	
	}
}
