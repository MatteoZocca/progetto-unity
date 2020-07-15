using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBar : MonoBehaviour
{
    public bool razzoDisponibile = false;
    public float difficulty;
    private float difficultyPercentage;
    private bool nonAttivato;
    public Rocket rocket;
    public GameObject readyPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (rocket == null)
            rocket = FindObjectOfType<Rocket>();

        this.GetComponent<Slider>().value = 0;
        if (float.TryParse(ParallaxSceneManager.Instance.SceneLoaded, out difficulty))
            difficultyPercentage = 50 * difficulty;
        else
        {
            Debug.LogError($"Parse non riuscito {ParallaxSceneManager.Instance.SceneLoaded}");
            difficultyPercentage = 50;
        }
        nonAttivato = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket != null && rocket.IsEnter) return;

        //Debug.Log(SceneChanger.currentLevel);
        if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().maxValue)
            razzoDisponibile = true;

        if (razzoDisponibile && nonAttivato)//display ready se razzo prontu 
        {
            readyPanel.SetActive(true);

            nonAttivato = false;
        }

        this.GetComponent<Slider>().value += Time.deltaTime / difficultyPercentage;
    }
}
