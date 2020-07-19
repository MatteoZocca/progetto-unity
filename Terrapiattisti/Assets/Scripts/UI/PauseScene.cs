using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public void Toggle()
    {
        ParallaxGameManager.Instance.PauseGame();
    }
}
