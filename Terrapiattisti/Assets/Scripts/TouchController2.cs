using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController2 : MonoBehaviour
{
    public Joystick ljoystick;
    public Transform astronauta;
    public float velocita = 5;
    private Vector3 vettoreMovimento;
    private Vector3 forwardIniziale;
    public float rotaspeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if(astronauta == null)
            astronauta = GameObject.FindGameObjectWithTag("Player").transform;
        forwardIniziale = astronauta.forward;
    }

    // Update is called once per frame
    void Update()
    {

        vettoreMovimento = new Vector3(ljoystick.Horizontal, 0f, ljoystick.Vertical);
        float heading = Mathf.Atan2(ljoystick.Horizontal, ljoystick.Vertical);
        float angle = Vector3.SignedAngle(astronauta.forward, vettoreMovimento, this.transform.up);
        
        Debug.DrawLine(this.transform.position, vettoreMovimento);
        //Debug.DrawRay(this.transform.position, vettoreMovimento, Color.red, 0.5f);
        //astronauta.up = this.transform.up;
        //astronauta.rotation = Quaternion.LookRotation(vettoreMovimento, this.transform.up);
        this.transform.Translate(vettoreMovimento * velocita * Time.deltaTime);
        Vector3 rotazionea = astronauta.rotation.eulerAngles;

        if (ljoystick.Horizontal != 0 && ljoystick.Vertical != 0)
        {
            astronauta.Rotate(new Vector3(0f, angle, 0f) * Time.deltaTime * rotaspeed);
        }

    }

    
}
