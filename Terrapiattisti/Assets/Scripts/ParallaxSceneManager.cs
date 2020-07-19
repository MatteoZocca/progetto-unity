using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ParallaxSceneManager : Singleton<ParallaxSceneManager>
{
    public string SceneLoaded => _sceneCurrentLoaded;

    public bool isLoading { get; private set; }

    private string _sceneCurrentLoaded;

    private void Awake()
    {
        _instance = this;
        
        DontDestroyOnLoad(this);

        if (string.IsNullOrEmpty(_sceneCurrentLoaded))
            _sceneCurrentLoaded = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneToLoad,Action onComplete)
    {
        StartCoroutine(ChangeScene(sceneToLoad,onComplete));
    }

    IEnumerator ChangeScene(string sceneName,Action onComplete)
    {
        isLoading = true;


        yield return SceneManager.LoadSceneAsync(sceneName).isDone;

        _sceneCurrentLoaded = sceneName;
        

        onComplete?.Invoke();
        isLoading = false;
    }
}
