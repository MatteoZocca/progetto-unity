using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChargingBar : MonoBehaviour
{
    public bool razzoDisponibile = false;
    public float difficulty;
    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField]
    private float timeToWait;
    private bool nonAttivato;
    public Rocket rocket;
    public GameObject readyPanel;

    private Slider _slider;

    void Start()
    {
        if (rocket == null)
            rocket = FindObjectOfType<Rocket>();

        _slider= this.GetComponent<Slider>();

        _slider.value = 0;
        _slider.maxValue = timeToWait;
        //if (float.TryParse(ParallaxSceneManager.Instance.SceneLoaded, out difficulty))
        //    difficultyPercentage = 50 * difficulty;
        //else
        //{
        //    Debug.LogError($"Parse non riuscito {ParallaxSceneManager.Instance.SceneLoaded}");
        //    difficultyPercentage = 50;
        //}
        nonAttivato = true;
        StartCoroutine(WaitBar());
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket != null && rocket.IsEnter) return;

        _timerText?.SetText($"Time : {Time.timeSinceLevelLoad.ToString("F2")}");

        if (razzoDisponibile && nonAttivato)//display ready se razzo prontu 
        {
            readyPanel.SetActive(true);

            nonAttivato = false;
        }
    }

    IEnumerator WaitBar()
    {
        while (_slider.value < timeToWait)
        {
            _slider.value += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        razzoDisponibile = true;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
