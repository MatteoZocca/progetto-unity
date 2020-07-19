using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour {
    public static int currentLevel;
    void Start() {
        currentLevel = GetLevel();
    }

    void Update()
    {

    }

    private int GetLevel() {
        return GameObject.Find("SelectedLevel").GetComponent<UnityEngine.UI.Text>().text[6] - '0';
    }

    public void SwitchLevel() {
        if (this.gameObject.tag == "Incrementer" && currentLevel != 4) {
            ++currentLevel;
        }
        else if (this.gameObject.tag == "Decrementer" && currentLevel != 1) {
            --currentLevel;
        }
        GameObject.Find("SelectedLevel").GetComponent<UnityEngine.UI.Text>().text = "LEVEL " + currentLevel.ToString();
    }
}
