using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScene : MonoBehaviour {

    private bool isPaused;

    void Start() {
        
        isPaused = false;
    }

    public void Toggle() {
        isPaused = !isPaused;

        if (!isPaused) {
            Resume();
        }
        else if (isPaused) {
            Pause();
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
    }

    public void Resume() {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
