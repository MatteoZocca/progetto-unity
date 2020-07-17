using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParallaxGameManager : Singleton<ParallaxGameManager>
{
    public bool IsPaused => _isPaused;

    private bool _isPaused;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
        SceneManager.activeSceneChanged += SceneChanged;
    }

    private void SceneChanged(Scene oldScene, Scene newScene)
    {
        StartCoroutine(aspetta());
    }

    public void PauseGame()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    IEnumerator aspetta()
    {
        yield return new WaitForSeconds(2f);
        _isPaused = false;
    }
}
