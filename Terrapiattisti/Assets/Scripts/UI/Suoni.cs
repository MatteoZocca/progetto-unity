using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suoni : MonoBehaviour
{
    private bool status;
    // Start is called before the first frame update
    void Start()
    {
        status=this.GetComponent<Toggle>().isOn;
    }

 public void Click()
    {

        status = this.GetComponent<Toggle>().isOn;
        if (status)
            AudioListener.volume = 1;

        else
            AudioListener.volume = 0;
             
    }
}
