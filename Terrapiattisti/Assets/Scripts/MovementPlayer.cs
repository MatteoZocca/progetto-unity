using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variabile velocità
    [SerializeField] // compare nell'Inspector, anche public lo fa, con la differenza che la rende visibile ad altre classi.
    float speed = 5;
    Vector3 vettoreMovimento; // vettore che indica la direzione del movimento

    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        // freeza la rotazione del personaggio, tiene sempre i piedi rivolti verso la terra.
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal"); //salvo input asse X
        float movementY = Input.GetAxis("Vertical"); // salvo input asse Y
        vettoreMovimento = new Vector3(movementX, 0, movementY); // creo un nuovo vettore di movimento 
            this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
            // traslo l'oggetto in questione per un valore di velocità * una variabile di tempo che varia a seconda del PC.    
    }

    void FixedUpdate()
    {
       // this.GetComponent<Rigidbody>().MovePosition(this.GetComponent<Rigidbody>().position + vettoreMovimento * speed * Time.deltaTime);
    }
}
