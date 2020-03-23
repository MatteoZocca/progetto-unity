using System;
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
    [SerializeField]
    private Quaternion cambiorotazione;
    private Vector3 cambiodirezione;
    bool giratoav = true;
    bool giratosx = false;
    private bool giratodx = false;
    bool giratodt = false;
    float inverti = 0;
    [SerializeField]
    private float rotationspeed = 200;
    GameObject parentrigidbody;
    private bool isRotating;
    private void Start()
    {
        astronauta = GameObject.FindGameObjectWithTag("Player").transform;
        parentrigidbody = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        // MATTEO: se vuoi che l'input non sia "lerpato" e che scatti tipo alla dark souls, usa Input.GetAxisRaw()
        float movementX = Input.GetAxis("Horizontal"); //salvo input asse X
        float movementY = Input.GetAxis("Vertical"); // salvo input asse Y

        /* Comunque, da quello che ho visto in pratica non calcoli la diagonale, per cui quello va solo nelle 4 direzioni
         * per ora ho messo che deve aspettare che il player aspetti di ruotare per poi fare altre cose
         * 
         */
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!giratoav && !isRotating)
            {
                isRotating = true;
                giratoav = true;
                giratodx = false;
                giratodt = false;
                giratosx = false;
                //cambiorotazione = Quaternion.LookRotation(-astronauta.forward, astronauta.up);
                //StartCoroutine(PerformRotation(cambiorotazione));
                //astronauta.rotation = Quaternion.Euler(0f, 0f, 0f);
                //astronauta.Rotate(new Vector3(0, 180f));
                cambiorotazione = Quaternion.LookRotation(parentrigidbody.transform.forward, parentrigidbody.transform.up);
                StartCoroutine(PerformRotation(cambiorotazione, () => { isRotating = false; }));
                Debug.Log("Forward");
                inverti = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!giratosx && !isRotating)
            {
                isRotating = true;
                giratosx = true;
                giratodt = false;
                giratoav = false;
                giratodx = false;
                cambiorotazione = Quaternion.LookRotation(parentrigidbody.transform.right *-1, parentrigidbody.transform.up);
                StartCoroutine(PerformRotation(cambiorotazione,() => { isRotating = false; }));
                Debug.Log("Right");
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // NANI !? perchè qua non si controlla se è girato ? 
            if (!giratodx && !isRotating)
            {
                isRotating = true;
                giratosx = false;
                giratodt = false;
                giratoav = false;
                giratodx = true;
                cambiorotazione = Quaternion.LookRotation(parentrigidbody.transform.right, parentrigidbody.transform.up);
                StartCoroutine(PerformRotation(cambiorotazione, () => { isRotating = false; }));
                Debug.Log("Left");
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!giratodt && !isRotating) // Se non è girato
            {
                isRotating = true;
                giratodt = true;
                giratoav = false;
                giratosx = false;
                giratodx = false;
                               //astronauta.transform.rotation = Quaternion.Slerp(astronauta.transform.rotation, cambiorotazione, 1f * rotationspeed * Time.deltaTime);
                               //cambiorotazione = astronauta.rotation * Quaternion.Euler(0, 180f, 0);
                cambiorotazione = Quaternion.LookRotation(-parentrigidbody.transform.forward, parentrigidbody.transform.up);
                               //astronauta.Rotate(new Vector3(0, 180f));
                StartCoroutine(PerformRotation(cambiorotazione, () => { isRotating = false; }));
                Debug.Log("Back");
                inverti = 0; // e inverti i comandi
            }
        }
        if (giratoav || giratodt)
            vettoreMovimento = new Vector3(0, 0, movementY);
        else
            vettoreMovimento = new Vector3(movementX, 0, 0);
        if(inverti == 1f)
            vettoreMovimento.Scale(new Vector3(-1, -1, -1));
        this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
            // traslo l'oggetto in questione per un valore di velocità * una variabile di tempo che varia a seconda del PC. 
         
    }

    IEnumerator PerformRotation(Quaternion targetRotation, Action onComplete)
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
        onComplete?.Invoke();
    }

}
