using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongController : MonoBehaviour {

	public AudioClip[] tracks;
	public AudioSource audioSource;

	int tracksList;

	public bool playing;

	[Header("Casete")]
	public GameObject casete;

	public GameObject Laser;


	void OnLevelWasLoaded() {
		casete = GameObject.FindGameObjectWithTag ("Casete");
		Laser = GameObject.FindGameObjectWithTag ("Laser");

		playing = false;
		displayCasete ();
	}

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (Laser.GetComponent<Laser>().activeLaser == false) {
			this.gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = Mathf.Lerp (this.gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency, 9000f, 2*Time.deltaTime);
			this.GetComponent<AudioLowPassFilter> ().lowpassResonanceQ = Mathf.Lerp (this.GetComponent<AudioLowPassFilter> ().lowpassResonanceQ, 1f, 10*Time.deltaTime);

			if (this.gameObject.GetComponent<AudioLowPassFilter> ().cutoffFrequency > 8000f) {
				this.gameObject.GetComponent<AudioLowPassFilter> ().enabled = false;
			}
		}

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
		displayCasete ();
	}

	// Casete display
	void displayCasete()
	{
		if (playing == false) {
			Invoke ("display", 0f);
		}
	}
	void display()
	{
		casete.SetActive (true);
		Invoke ("unDisplay", 20f);
	}
	void unDisplay(){
		casete.SetActive (false);
	}
}
