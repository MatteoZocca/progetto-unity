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
    public GameObject readyPanel;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = 0;
        difficulty = SceneChanger.currentLevel;
        difficultyPercentage = 50 * difficulty;
        nonAttivato = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SceneChanger.currentLevel);
        if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().maxValue)
            razzoDisponibile = true;

        if (razzoDisponibile && nonAttivato)//display ready se razzo prontu 
        {
            readyPanel.SetActive(true);
           
           nonAttivato = false;
        }

        this.GetComponent<Slider>().value += Time.deltaTime / difficultyPercentage;

        Debug.Log(SceneChanger.currentLevel);

    }
}
