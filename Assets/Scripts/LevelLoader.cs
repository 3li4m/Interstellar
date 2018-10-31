using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void Restart()
	{
		SceneManager.LoadScene (0);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
