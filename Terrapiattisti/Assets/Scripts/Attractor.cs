using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Questa classe permette agli elementi di gioco di essere attratti da questo centro di gravità, in questo caso la terra*/

public class Attractor : MonoBehaviour
{
    public float gravity = -10;
    private Vector3 vettoreTerra;
    void Start()
    {
        vettoreTerra = this.transform.position;
    }

    public void GravityOggetto(Transform body)
    {
        Vector3 gravityUp = (body.position - vettoreTerra).normalized; //differenza tra posizione attuale elemento e vettoreTerra
        Vector3 positionBody = body.up; // ritorna il vettore (0,1,0) relativo alla rotazione dell'oggetto, ovvero l'asse Y rispetto al GameObject

        body.GetComponent<Rigidbody>().AddForce(gravity * gravityUp); // aggiunge forza di gravità all'oggetto passato

        Quaternion targetRotation = Quaternion.FromToRotation(positionBody, gravityUp) * body.rotation; //ruota l'oggetto
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }

}
