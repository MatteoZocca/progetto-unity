using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public static float currentLevel;
    public void ChangeScene(string sceneName) {

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        
    }

    public void UpdateCurrentLevel() {
        currentLevel = float.Parse(this.gameObject.name);
    }
}
