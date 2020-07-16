using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject FloatingJoystick;
    public GameObject CavernicoloCartello;
    public GameObject EnemySpawner;
    private bool finito = false;
    private bool finito1 = false;
    private bool finito2 = false;
    private bool finito3 = false;
    private bool finito4 = false;

    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            this.GetComponent<tutorial>().enabled = false;
        }
        else
        {
            CavernicoloCartello.SetActive(false);
            EnemySpawner.SetActive(false);
            panel1.SetActive(true);
            FloatingJoystick.SetActive(false);
            GameObject.Find("Icon").GetComponent<RawImage>().enabled = false;
            GameObject.Find("ChargingBar").GetComponent<ChargingBar>().enabled = false;
            GameObject.Find("ImmRazzo").GetComponent<Image>().enabled = false;
            GameObject.Find("BackgroundBarra").GetComponent<Image>().enabled = false;
            GameObject.Find("Fill").GetComponent<Image>().enabled = false;
            GameObject.Find("Cuore").GetComponent<Image>().enabled = false;
            GameObject.Find("BackgroundLifeBar").GetComponent<Image>().enabled = false;
            GameObject.Find("FillLife").GetComponent<Image>().enabled = false;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !finito1)
        {
            finito1 = true;
            panel1.SetActive(false);
            StartCoroutine(waitSecond(panel2));

        }

        if (finito)
        {
            FloatingJoystick.SetActive(true);
            if (Input.GetMouseButtonDown(0))
                    {
                        if (!finito2)
                        {
                            finito = false;
                            finito2 = true;
                            panel2.SetActive(false);
                            StartCoroutine(waitSecond(panel3));
                        }
                    }
        }

        if (finito && finito2)
        {
            GameObject.Find("Icon").GetComponent<RawImage>().enabled = true;
            GameObject.Find("ImmRazzo").GetComponent<Image>().enabled = true;
            GameObject.Find("BackgroundBarra").GetComponent<Image>().enabled = true;
            GameObject.Find("Fill").GetComponent<Image>().enabled = true;
            GameObject.Find("Cuore").GetComponent<Image>().enabled = true;
            GameObject.Find("BackgroundLifeBar").GetComponent<Image>().enabled = true;
            GameObject.Find("FillLife").GetComponent<Image>().enabled = true;

            if (Input.GetMouseButtonDown(0))
                    {
                        if (!finito3)
                        {
                            finito = false;
                            finito3 = true;
                            panel3.SetActive(false);
                            StartCoroutine(waitSecond(panel4));
                        }
                    }
        }
        
        if(finito && finito3)
        {

            if (Input.GetMouseButtonDown(0))
                    {
                        if (finito && !finito4)
                        {
                            finito = false;
                            finito4 = true;
                            panel4.SetActive(false);
                            GameObject.Find("ChargingBar").GetComponent<ChargingBar>().enabled = true;
                            CavernicoloCartello.SetActive(true);
                            EnemySpawner.SetActive(true);
                            PlayerPrefs.SetInt("Tutorial", 1); 

                }
            }
        }
        




    }

    IEnumerator waitSecond(GameObject panel)
    {
        yield return new WaitForSeconds(3f);
        panel.SetActive(true);
        finito = true;
    }
}
