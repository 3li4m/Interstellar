using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour 
{
	public int score;
	public int wave;
	public Text scoreTxt;
	public Text waveTxt;

	public float sliderVal;
	public Slider slider;

	public Text cdTxt;

	public Text gameOverTxt;
	public GameObject gameOverPannel;
	public bool gameOver;

	public GameObject UireadyParticle;

	public GameObject songAudio;
	public Text songAudioTxt;

	Scene scene;
	public bool inGame;
	void Start () {
		songAudio = GameObject.FindGameObjectWithTag ("SongAudio");
		score = 0;
		sliderVal = 0;
		scene = SceneManager.GetActiveScene ();
	}
	
	void Update () {
		if (scene.name != "MainMenu") {
			scoreTxt.text = "" + score.ToString ();
			waveTxt.text = "" + wave.ToString ();
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
	}
}
