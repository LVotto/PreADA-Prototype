using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {
    int ticksElapsed = 0;
    public int clockRate = 20;
    public int timer = 0;

    public bool showTimeElapsed;
    bool isPaused;

    public AudioSource bassFX;

    void Update() {
        if (Input.GetKeyDown("p")) {
            isPaused = !isPaused;
        }
        if (!isPaused && timer == 0 && ticksElapsed < 4) bassFX.Play();
    }

    void FixedUpdate() {
        if (!isPaused) {
            if (timer < clockRate) {
                timer++;
            } else {
                timer = 0;
                ticksElapsed++;
                if (showTimeElapsed) Debug.Log(ticksElapsed);
            }
        }
    }
}
