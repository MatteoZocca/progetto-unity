using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    private PauseScene pausa;
    public GameObject panel;
    public GameObject checkBar;
    private bool vivo;
    void Start()
    {
        slider = GameObject.Find("lifebar").GetComponent<Slider>();
        pausa = GameObject.Find("MenuButton").GetComponent<PauseScene>();
        vivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0 && vivo)
        {
            vivo = false;
            checkBar.SetActive(false);
            panel.SetActive(true);
            pausa.Pause();
        }
    }
}
