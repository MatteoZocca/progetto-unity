using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Questo classe descrive un elemento passivo che viene attratto da un elemento, in questo caso la terra */

public class BodyAttracted : MonoBehaviour
{
    public Attractor attrattore;
    
    void Start()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        this.GetComponent<Rigidbody>().useGravity = false;
        // freeza la rotazione dell'elemento, tiene sempre i piedi rivolti verso la terra.
    }

    
    void Update()
    {
        //Chiama funzione ogni volta per tenere attaccato l'oggetto.
        attrattore.GravityOggetto(this.transform);
    }
}
