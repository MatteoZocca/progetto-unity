﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPlayer : MonoBehaviour
{
    public Transform metarig;
    public float raggioCattura;
    TouchController touch;
    public Checker checker;
    private bool checkerDone;
    private GameObject joystickdestro;
    // Start is called before the first frame update
    void Start()
    {
        touch = this.GetComponent<TouchController>();
        checker.OnSkillCheckDone.AddListener(checkDone);
        joystickdestro = GameObject.Find("Floating Joystick");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkerDone)
            return;

        Collider[] hitColliders = Physics.OverlapSphere(metarig.position, raggioCattura);
        
        foreach (Collider coll in hitColliders) {
            if (coll.transform.tag == "mani" && touch.fermate != true)
            {
                    touch.fermate = true;
                    checker.gameObject.SetActive(true);
                    joystickdestro.SetActive(false);
            }
        }
    }

    private void checkDone(bool done)
    {
        if (done)
        {
            checkerDone = true;
            checker.gameObject.SetActive(false);
            touch.fermate = false;
            joystickdestro.SetActive(true);
            StartCoroutine(staiFermo());
        }
        //do nothing
    }

    IEnumerator staiFermo()
    {
        yield return new WaitForSeconds(3f);
        checkerDone = false;

    }
    

}