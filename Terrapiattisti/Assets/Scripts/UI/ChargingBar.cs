using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBar : MonoBehaviour
{
    public bool razzoDisponibile = false;
    public float difficulty;
    private float difficultyPercentage;
    private bool nonattivato;
    public GameObject readyPanel;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = 0;
        difficulty = 1;
        difficultyPercentage = 50 * difficulty;
        nonattivato = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().maxValue)
            razzoDisponibile = true;

        if (razzoDisponibile && nonattivato)//display ready se razzo prontu 
        {
            readyPanel.SetActive(true);
           
           nonattivato = false;
        }

        this.GetComponent<Slider>().value += Time.deltaTime / difficultyPercentage;



    }
}
