using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsToggler : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsWithSoundEffects;
    private bool status;
    // Start is called before the first frame update
    void Start() {
        objectsWithSoundEffects = GetObjectsWithSound();
        status = this.GetComponent<Toggle>().isOn;
    }

    private GameObject[] GetObjectsWithSound() {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        for (int i = 0; i < objects.Length; i++) {
            if (objects[i].GetComponent<AudioSource>() == null || objects[i].name == "Jukebox")
                objects[i] = null;
        }
        return objects;
    }

    public void ChangeStatus() {
        for (int i = 0; i < objectsWithSoundEffects.Length; i++) {
            if (objectsWithSoundEffects[i] != null) {
                objectsWithSoundEffects[i].GetComponent<AudioSource>().mute = status;
            }
        }
    }

    public void Update() {
        status = this.GetComponent<Toggle>().isOn;
    }
}
