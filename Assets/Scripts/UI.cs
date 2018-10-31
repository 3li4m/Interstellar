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

	void Start () {
		score = 0;
		sliderVal = 0;
	}
	
	void Update () {
		scoreTxt.text = "" + score.ToString ();
		waveTxt.text = "" + wave.ToString ();
		slider.value = sliderVal;
		cdTxt.text = "COOLING DOWN";
	}
}
