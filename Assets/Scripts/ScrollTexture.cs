using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour {

	// Scroll main texture based on time

	public float scrollSpeed = 0.5f;
	public float offsetX;
	public float offsetY;
	Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer> ();
	}

	void Update()
	{
		offsetY= Time.time * scrollSpeed;
		offsetX= Time.time * scrollSpeed;
		rend.material.mainTextureOffset = new Vector2 (offsetX, offsetY);
		//rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
