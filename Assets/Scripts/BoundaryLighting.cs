using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryLighting : MonoBehaviour {
	Color color = Color.red;
	public Renderer ren;
	public float colorSpeed;
	public bool collided;
	void Start()
	{
		collided = false;
		color.a = 0;
		ren = gameObject.GetComponent<Renderer> ();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			collided = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			collided = false;
		}
	}

	void Update()
	{
		if (collided) {
			ren.material.SetColor ("_TintColor", Color.Lerp (ren.material.GetColor ("_TintColor"),
				new Color (255f, 0f, 0f, 1f), colorSpeed * Time.deltaTime));
		} else {
			ren.material.SetColor ("_TintColor", Color.Lerp (ren.material.GetColor ("_TintColor"),
				new Color (255f, 0f, 0f, 0f),colorSpeed * Time.deltaTime));
		}
	}

}
