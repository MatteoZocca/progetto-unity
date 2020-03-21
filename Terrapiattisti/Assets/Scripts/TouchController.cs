using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Joystick joystick;
    public Joystick rjoystick;
    private Vector3 vettore;
    [SerializeField] // compare nell'Inspector, anche public lo fa, con la differenza che la rende visibile ad altre classi.
    float speed = 5;
    private Vector3 vettoreMovimento;
    // Update is called once per frame

    void Update()
    {
        float movementX = joystick.Horizontal; //salvo input asse X
        float movementY = joystick.Vertical; // salvo input asse Y
        vettoreMovimento = new Vector3(movementX, 0, movementY); // creo un nuovo vettore di movimento 
        this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
        this.transform.Rotate(0, rjoystick.Horizontal * 2.5f, 0);
    }
}
