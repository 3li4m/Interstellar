using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour {
    public MeshRenderer playerModel;
    public float timer;
    private float currTimer;
    private bool onFlash = false;
    // Update is called once per frame
    private void Start()
    {
        currTimer = timer;
    }

    void Update () {
        if (onFlash)
        {
            flash();
        }
	}

    private void flash() {
        if (currTimer < 0)
        {
            playerModel.enabled = !playerModel.enabled;
            currTimer = timer;
        }
        else
        {
            currTimer -= Time.deltaTime;
        }
    }

    public void turnOffFlash() {
        currTimer = timer;
        playerModel.enabled = true;
        onFlash = false;
    }

    public void turnOnFlash() {
        currTimer = timer;
        playerModel.enabled = true;
        onFlash = true;
    }
}
