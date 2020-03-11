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
        
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

          if(movementX != 0 || movementY != 0)
        {
            Vector3 vettoreMovimento = new Vector3(movementX, movementY, 0);
            this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
        }    
    }
}
