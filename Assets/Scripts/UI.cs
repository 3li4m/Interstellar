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

	void Start () {
		score = 0;

	}
	
	void Update () {
		scoreTxt.text = "" + score.ToString ();
		waveTxt.text = "" + wave.ToString ();
	}
}
