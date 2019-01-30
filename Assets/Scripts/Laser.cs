using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {


	public GameObject music;
	public GameObject gunSound;


	public AudioClip laserHeavy;
	public AudioClip laser;

	public AudioSource audioSource;

	public DealDamage deactivate;
	public bool activeLaser;


	public GameObject[] randWep;
	public ParticleSystem[] emitter;

	public float laserSpecialTimer;
	int rand;

	void Start () 
	{
		rand = Random.Range (0, randWep.Length);
	}

	void OnLevelWasLoaded() {
		music = GameObject.FindGameObjectWithTag ("SongAudio");
		gunSound = GameObject.FindGameObjectWithTag ("weaponSounds");

	}

	void Update () 
	{
		
		Invoke ("fadeOut", laserSpecialTimer);
		Invoke ("musicFilter",1f);
		if (activeLaser) {
			music.GetComponent<AudioLowPassFilter> ().enabled = true;
			music.GetComponent<AudioLowPassFilter> ().cutoffFrequency = Mathf.Lerp (music.GetComponent<AudioLowPassFilter> ().cutoffFrequency, 100f, Time.deltaTime*3);
			music.GetComponent<AudioLowPassFilter> ().lowpassResonanceQ = Mathf.Lerp (music.GetComponent<AudioLowPassFilter> ().lowpassResonanceQ, 1.5f, 2*Time.deltaTime);


			if (!audioSource.isPlaying) {
				audioSource.volume = 0.300f;
				audioSource.clip = laserHeavy;
				audioSource.PlayOneShot (laserHeavy);
			}
		} 
	}

	//turns off emitters
	void fadeOut()
	{
		gunSound.GetComponent<AudioLowPassFilter> ().enabled = true;
		gunSound.GetComponent<AudioLowPassFilter> ().cutoffFrequency = 5000f;

		activeLaser = false;
		audioSource.volume = 0.02f;
		audioSource.clip = laser;

		print (rand);
		randWep [rand].SetActive (true);
		//Destroy (gameObject, .5f);
		this.gameObject.SetActive (false);
	}
}
