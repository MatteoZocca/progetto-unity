using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingBar : MonoBehaviour
{
    public bool razzoDisponibile = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Slider>().value == 1)
            razzoDisponibile = true;

        this.GetComponent<Slider>().value += Time.deltaTime / 100;

    }
}
