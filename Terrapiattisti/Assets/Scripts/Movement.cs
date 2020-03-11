using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // variabile velocità
    [SerializeField] // compare nell'Inspector, anche public lo fa, con la differenza che la rende visibile ad altre classi.
    float speed = 5;
    void Start()
    {
        // vuoto non faccio nulla all'avvio del gioco
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal"); //salvo input asse X
        float movementY = Input.GetAxis("Vertical"); // salvo input asse Y

          if(movementX != 0 || movementY != 0) // verifico se c'è stato movimento
        {
            Vector3 vettoreMovimento = new Vector3(movementX, movementY, 0); // creo un nuovo vettore di movimento 
            this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
            // traslo l'oggetto in questione per un valore di velocità * una variabile di tempo che varia a seconda del PC.
        }    
    }
}
