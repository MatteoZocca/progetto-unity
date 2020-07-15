using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconChanger : MonoBehaviour {
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

    void Start() {
        this.GetComponent<Image>().sprite = on;
    }

    public void ChangeIcon() {
        if (this.GetComponent<Image>().sprite == on)
            this.GetComponent<Image>().sprite = off;
        else
            this.GetComponent<Image>().sprite = on;
    }
}
