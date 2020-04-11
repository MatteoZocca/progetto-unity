﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Joystick joystick;
    public Joystick rjoystick;
    private Vector3 vettore;
    [SerializeField] // compare nell'Inspector, anche public lo fa, con la differenza che la rende visibile ad altre classi.
    private float velocita = 5;
    [SerializeField]
    private float rotationspeed = 5;
    private Vector3 vettoreMovimento;
    // Update is called once per frame
    private Quaternion cambiorotazione;
    private Transform astronauta;
    private GameObject parentrigidbody;
    bool giratoav = true;
    bool giratosx = false;
    bool giratodx = false;
    bool giratodt = false;

    private void Start()
    {
        astronauta = GameObject.FindGameObjectWithTag("Player").transform;
        parentrigidbody = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        float movementX = joystick.Horizontal; //salvo input asse X
        float movementY = joystick.Vertical; // salvo input asse Y

        if (Mathf.Abs(movementX) > Mathf.Abs(movementY))
        {
            if(movementX < 0)
            {
                if (!giratosx)
                {
                    giratosx = true;
                    giratodt = false;
                    giratoav = false;
                    giratodx = false;
                    rjoystick.enabled = false;
                    rjoystick.AxisOptions = AxisOptions.Vertical;
                    cambiorotazione = Quaternion.LookRotation(parentrigidbody.transform.right * -1, parentrigidbody.transform.up);
                    StartCoroutine(PerformRotation(cambiorotazione, () => { rjoystick.enabled = true; }));
                }
            }
            else if(movementX > 0)
            {
                if (!giratodx)
                {
                    giratodx = true;
                    giratodt = false;
                    giratoav = false;
                    giratodt = false;
                    rjoystick.enabled = false;
                    rjoystick.AxisOptions = AxisOptions.Vertical;
                    cambiorotazione = Quaternion.LookRotation(parentrigidbody.transform.right, parentrigidbody.transform.up);
                    StartCoroutine(PerformRotation(cambiorotazione, () => { rjoystick.enabled = true; }));
                }
            }

        }
        else
        {
            if(movementY > 0)
            {
                if (!giratoav)
                {
                    giratoav = true;
                    giratodx = false;
                    giratodt = false;
                    giratosx = false;
                    //cambiorotazione = Quaternion.LookRotation(-astronauta.forward, astronauta.up);
                    //StartCoroutine(PerformRotation(cambiorotazione));
                    //astronauta.rotation = Quaternion.Euler(0f, 0f, 0f);
                    //astronauta.Rotate(new Vector3(0, 180f));
                    rjoystick.enabled = false;
                    rjoystick.AxisOptions = AxisOptions.Horizontal;
                    cambiorotazione = Quaternion.LookRotation(parentrigidbody.transform.forward, parentrigidbody.transform.up);
                    StartCoroutine(PerformRotation(cambiorotazione, () => { rjoystick.enabled = true; }));
                }
            }
            else if (movementY < 0)
            {
                if (!giratodt) // Se non è girato
                {
                    giratodt = true;
                    giratoav = false;
                    giratosx = false;
                    giratodx = false;
                    //astronauta.transform.rotation = Quaternion.Slerp(astronauta.transform.rotation, cambiorotazione, 1f * rotationspeed * Time.deltaTime);
                    //cambiorotazione = astronauta.rotation * Quaternion.Euler(0, 180f, 0);
                    rjoystick.enabled = false;
                    rjoystick.AxisOptions = AxisOptions.Horizontal;
                    cambiorotazione = Quaternion.LookRotation(-parentrigidbody.transform.forward, parentrigidbody.transform.up);
                    //astronauta.Rotate(new Vector3(0, 180f));
                    StartCoroutine(PerformRotation(cambiorotazione, () => { rjoystick.enabled = true; }));
                }
            }
        }
        if(Mathf.Abs(movementY) > Mathf.Abs(movementX))
            vettoreMovimento = new Vector3(0, 0, movementY); // creo un nuovo vettore di movimento 
        else
            vettoreMovimento = new Vector3(movementX, 0, 0);

        //this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
        this.transform.Translate(vettoreMovimento * velocita * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (rjoystick.enabled) {
            if(giratoav || giratodt)
                parentrigidbody.transform.Rotate(0, rjoystick.Horizontal * 2f, 0);
            if (giratosx)
                parentrigidbody.transform.Rotate(0, rjoystick.Vertical * 2f, 0);
            else
                parentrigidbody.transform.Rotate(0, rjoystick.Vertical * -2f, 0);
        }
            
    }

    IEnumerator PerformRotation(Quaternion targetRotation, System.Action onFinish)
    {

        float progress = 0f;
        while (progress < 1f)
        {
            astronauta.rotation = Quaternion.Slerp(astronauta.rotation, targetRotation, progress);
            progress += Time.deltaTime * rotationspeed;

            if (progress <= 1f)
            {
                yield return null;
            }
        }
        rjoystick.enabled = true;

    }
}