using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour 
{
	[Header("Score")]
	public int score;
	public int wave;
	public Text scoreTxt;
	public Text waveTxt;

	[Header("PowerBar")]
	public float sliderVal;
	public Slider slider;

	public Text cdTxt;

	[Header("Gameover")]
	public GameObject[] lives;
	public GameObject player;
	public Text gameOverTxt;
	public GameObject gameOverPannel;
	public bool gameOver;

	public GameObject UireadyParticle;

	[Header("Audio")]
	public GameObject songAudio;
	public Text songAudioTxt;

	[Header("SpawnTime")]
	public GameObject waveSpawnObj;
	public Text waveSpawnTimeTxt;
	public float waveTime;

	[Header("InGameCheck")]
	Scene scene;
	public bool inGame;

	[Header("Casete")]
	public GameObject casete;
	public SongController isPlaying;

	void Start () 
	{
		songAudio = GameObject.FindGameObjectWithTag ("SongAudio");
		player = GameObject.FindGameObjectWithTag ("Player");

		score = 0;
		sliderVal = 0;
		scene = SceneManager.GetActiveScene ();
		displayCasete ();
	}
	
	void Update () 
	{
		if (scene.name != "MainMenu") {
			
			scoreTxt.text = "" + score.ToString ();
			waveTxt.text = "" + wave.ToString ();
			waveSpawnTimeTxt.text = "" + Mathf.RoundToInt(waveTime).ToString ();
			slider.value = sliderVal;
			cdTxt.text = "COOLING DOWN";

			if (slider.value == 100) {
				UireadyParticle.SetActive (true);
			} else {
				UireadyParticle.SetActive (false);
			}
			if (gameOver) {
				gameOverTxt.gameObject.SetActive (true);
				gameOverTxt.text = "Game Over";
				gameOverPannel.SetActive (true);
			}
		}
		songAudioTxt.text = "Now Playing " + songAudio.GetComponent<AudioSource>().clip.name;
		displayCasete ();
		removeLife ();
	}

	void removeLife()
	{
		switch (player.GetComponent<Respawn> ().lives) {
		case 3:
			lives [0].SetActive (false);
			break;
		case 2:
			lives [1].SetActive (false);
			break;
		case 1:
			lives [2].SetActive (false);
			break;
		case 0:
			lives [3].SetActive (false);
			break;
		}
	}

	// Casete display
	void displayCasete()
	{
		if (isPlaying.playing == false) {
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
