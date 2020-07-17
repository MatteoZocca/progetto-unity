using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public void ChangeScene(string sceneName)
    {
        ParallaxSceneManager.Instance.LoadScene(sceneName,SceneLoaded);
    }

    public void ChangeScene() {
        string levelName = this.GetComponent<UnityEngine.UI.Text>().text[6].ToString();
        ChangeScene(levelName);
    }

    public void Retry()
    {
        ParallaxSceneManager.Instance.LoadScene(ParallaxSceneManager.Instance.SceneLoaded,SceneLoaded);
    }

    private void SceneLoaded()
    {
        Time.timeScale = 1;
    }
}
