using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variabile velocità
    [SerializeField] // compare nell'Inspector, anche public lo fa, con la differenza che la rende visibile ad altre classi.
    float speed = 5;
    Vector3 vettoreMovimento; // vettore che indica la direzione del movimento
    public Transform astronauta;
    private Vector3 forwardiniziale;
    public float rotaspeed = 10;

    private void Start()
    {
        forwardiniziale = astronauta.forward;
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal"); //salvo input asse X
        float movementY = Input.GetAxis("Vertical"); // salvo input asse Y
        vettoreMovimento = new Vector3(movementX, 0, movementY); // creo un nuovo vettore di movimento 
        Vector3 vettoreRelativoPlayer = this.transform.TransformDirection(vettoreMovimento);
        float angle = Vector3.SignedAngle(astronauta.forward, vettoreRelativoPlayer, this.transform.up);
        this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
        // traslo l'oggetto in questione per un valore di velocità * una variabile di tempo che varia a seconda del PC.    

        if (vettoreMovimento != Vector3.zero)
            astronauta.Rotate(new Vector3(0f, angle, 0f) * Time.deltaTime * rotaspeed, Space.Self);
    }
}
