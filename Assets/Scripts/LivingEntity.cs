using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour {
	public float startingHp = 100;
	public float health;
	protected bool dead;

	public int value;

	public GameObject ui;

	public event System.Action OnDeath;
	public GameObject shatterdObject;

	public CamShake shake;

	void Awake()
	{
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
			Die ();
		}
	}

	protected void Die () {
		dead = true;
	
		ui.GetComponent<UI> ().score += value;
		Instantiate (shatterdObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
		shake.shouldShake = true;
		if (OnDeath != null) {
			OnDeath();
		}
		GameObject.Destroy (gameObject);
	}
}
