using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variabile velocità
    [SerializeField] // compare nell'Inspector, anche public lo fa, con la differenza che la rende visibile ad altre classi.
    float speed = 100;
    Vector3 vettoreMovimento; // vettore che indica la direzione del movimento
    Transform astronauta;
    private Quaternion cambiorotazione;
    private Vector3 cambiodirezione;
    bool girato = false;
    float inverti = 0;
    [SerializeField]
    private float rotationspeed = 100;
    private void Start()
    {
        astronauta = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal"); //salvo input asse X
        float movementY = Input.GetAxis("Vertical"); // salvo input asse Y

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (girato)
            {
                girato = false;
                //cambiorotazione = Quaternion.LookRotation(-astronauta.forward, astronauta.up);
                //StartCoroutine(PerformRotation(cambiorotazione));
                //astronauta.rotation = Quaternion.Euler(0f, 0f, 0f);
                astronauta.Rotate(new Vector3(0, 180f));
                inverti = 0;
            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!girato) // Se non è girato
            {
                girato = true; // giralo
                               //astronauta.transform.rotation = Quaternion.Slerp(astronauta.transform.rotation, cambiorotazione, 1f * rotationspeed * Time.deltaTime);
                               //cambiorotazione = astronauta.rotation * Quaternion.Euler(0, 180f, 0);
                               //cambiorotazione = Quaternion.LookRotation(-astronauta.forward, astronauta.up);
                astronauta.Rotate(new Vector3(0, 180f));
                //StartCoroutine(PerformRotation(cambiorotazione));

                inverti = 0; // e inverti i comandi
            }
        }
        
        vettoreMovimento = new Vector3(movementX, 0, movementY); // creo un nuovo vettore di movimento 
        if(inverti == 1)
            vettoreMovimento.Scale(new Vector3(-1, -1, -1));
        this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
            // traslo l'oggetto in questione per un valore di velocità * una variabile di tempo che varia a seconda del PC. 
         
    }

    IEnumerator PerformRotation(Quaternion targetRotation)
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
    }

}
