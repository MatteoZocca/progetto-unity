using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShow : MonoBehaviour
{
    [SerializeField] private GameObject UIObject = null;
    [SerializeField] private bool _deactivateOnStart;

    void Start()
    {
        if (_deactivateOnStart)
            UIObject.SetActive(false);
    }

    public void Toggle()
    {
        UIObject.SetActive(!UIObject.activeInHierarchy);
    }

}
