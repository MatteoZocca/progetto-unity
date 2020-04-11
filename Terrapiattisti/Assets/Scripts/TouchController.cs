using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Joystick ljoystick;
    public Joystick rjoystick;
    public Transform astronauta;
    public float velocity = 5;
    private Vector3 vettoreMovimento;
    private Vector3 forwardIniziale;
    public float rotaspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        if (astronauta == null)
            astronauta = GameObject.FindGameObjectWithTag("Player").transform;
        forwardIniziale = astronauta.forward;
    }

    // Update is called once per frame
    void Update()
    {

        vettoreMovimento = new Vector3(ljoystick.Horizontal, 0f, ljoystick.Vertical);
        Vector3 vettoreRelativoPlayer = transform.TransformDirection(vettoreMovimento); //trasforma il vettore locale in globale
        float angle = Vector3.SignedAngle(astronauta.forward, vettoreRelativoPlayer, this.transform.up);


        this.transform.Translate(vettoreMovimento * velocity * Time.deltaTime);
        this.transform.Rotate(0f, rjoystick.Horizontal * 2f, 0);

        if (vettoreMovimento != Vector3.zero)
        {
            astronauta.Rotate(new Vector3(0f, angle, 0f) * Time.deltaTime * rotaspeed, Space.Self);
        }

    }


}