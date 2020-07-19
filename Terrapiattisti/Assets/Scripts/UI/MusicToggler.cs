using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggler : MonoBehaviour {
    private bool status;
    private GameObject jukebox;
    // Start is called before the first frame update
    void Start()
    {
        status = this.GetComponent<Toggle>().isOn;
        jukebox = GameObject.Find("Jukebox");
    }

    public void Click()
    {

        status = this.GetComponent<Toggle>().isOn;
        if (status)
            jukebox.GetComponent<AudioSource>().Play();

        else
            jukebox.GetComponent<AudioSource>().Pause();

    }
}
