using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour {
	public float startingHp = 100;
	public float health;

	public int value;
	public float specialVal; 
	public GameObject shatterdObject;
	protected bool dead;
	public bool doTheShake;
	public event System.Action OnDeath;


	[Header("External Objects")]
	public CamShake shake;
	private GameObject player;
	public GameObject ui;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		ui = GameObject.FindGameObjectWithTag ("ScreenCanvas");
		shake = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CamShake>();
	}
	protected virtual void Start () {
		health = startingHp;

	}

	public void TakeHit(float damage)
	{
		health -= damage;
		if (health <= 0 && !dead) {
			if (!player.GetComponent<Special>().cooldown) {
				ui.GetComponent<UI> ().sliderVal += specialVal;
			}
			Die ();
		}
	}

	protected void Die () {
		dead = true;
	
		ui.GetComponent<UI> ().score += value;
		Instantiate (shatterdObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
		if (doTheShake) {
			shake.shouldShake = true;
		}
		if (OnDeath != null) {
			OnDeath();
		}
		GameObject.Destroy (gameObject);
	}
}
