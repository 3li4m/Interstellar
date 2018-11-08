using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour 
{
	public int score;
	public int wave;
	public Text scoreTxt;
	public Text waveTxt;

	public float sliderVal;
	public Slider slider;

	public Text cdTxt;

	public GameObject UireadyParticle;

	void Start () {
		score = 0;
		sliderVal = 0;
	}
	
	void Update () {
		scoreTxt.text = "" + score.ToString ();
		waveTxt.text = "" + wave.ToString ();
		slider.value = sliderVal;
		cdTxt.text = "COOLING DOWN";
		if (slider.value == 100) {
			UireadyParticle.SetActive (true);
		} else {
			UireadyParticle.SetActive (false);
		}
	}
}
