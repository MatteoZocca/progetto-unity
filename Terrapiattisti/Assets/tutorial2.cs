using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1;
    public GameObject FloatingJoystick;
    public GameObject CavernicoloCartello;
    public GameObject EnemySpawner2;
    public GameObject Cavernicolo;
    public GameObject EnemySpawner;
    public Checker checker;
    

    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial2") == 1)
        {
            this.GetComponent<tutorial2>().enabled = false;
        }
        else
        {
            checker.OnSkillCheckDone.AddListener(checkDone);
            Cavernicolo.SetActive(false);
            EnemySpawner2.SetActive(false);
            CavernicoloCartello.SetActive(false);
            EnemySpawner.SetActive(false);
            panel1.SetActive(true);
            checker.gameObject.SetActive(true);

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
       





    }

    private void checkDone(bool done)
    {
        if (done)
        {
            checker.gameObject.SetActive(false);
            panel1.SetActive(false);
            GameObject.Find("Icon").GetComponent<RawImage>().enabled = true;
            GameObject.Find("ChargingBar").GetComponent<ChargingBar>().enabled = true;
            GameObject.Find("ImmRazzo").GetComponent<Image>().enabled = true;
            GameObject.Find("BackgroundBarra").GetComponent<Image>().enabled = true;
            GameObject.Find("Fill").GetComponent<Image>().enabled = true;
            GameObject.Find("Cuore").GetComponent<Image>().enabled = true;
            GameObject.Find("BackgroundLifeBar").GetComponent<Image>().enabled = true;
            GameObject.Find("FillLife").GetComponent<Image>().enabled = true;
            Cavernicolo.SetActive(true);
            EnemySpawner2.SetActive(true);
            CavernicoloCartello.SetActive(true);
            EnemySpawner.SetActive(true);
            PlayerPrefs.SetInt("Tutorial2", 1);

        }

    }
}
