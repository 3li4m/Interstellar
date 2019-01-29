using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour {

	public AudioClip[] tracks;
	public AudioSource audioSource;

	int tracksList;

	public bool playing;

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		playing = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (!audioSource.isPlaying) {
			playing = false;
			if (tracksList != tracks.Length + 1) {
				audioSource.clip = tracks [tracksList];
				audioSource.Play ();
				tracksList++;
				print (tracksList);

			}
			if (tracksList >= tracks.Length) {
				tracksList = 0;
			}

		} else {
			playing = true;
		}

	}
}
