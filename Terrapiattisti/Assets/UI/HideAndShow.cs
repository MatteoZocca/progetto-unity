using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShow : MonoBehaviour {
    [SerializeField] private GameObject UIObject;
    private bool isActive;

    void Start() {
        isActive = false;
        this.UIObject.SetActive(isActive);
    }

    public void Toggle() {
        isActive = !isActive;
        this.UIObject.SetActive(isActive);
    }
}
