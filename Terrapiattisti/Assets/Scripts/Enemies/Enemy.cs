using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private Vector3 vettoredirezione;
    private Vector3 vettorePosizione;
    public Transform pianeta;
    private float speed;
    System.Random rdn;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        
        speed = Random.RandomRange(1f, 4f);
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posizione = (transform.position - pianeta.position);

       
        vettoredirezione = (target.transform.position - this.transform.position).normalized;
        Vector3 vettoreMovimento = (transform.position - pianeta.position) + vettoredirezione;
        Vector3 spostamento = (vettoreMovimento - posizione);
        //Debug.DrawRay(this.transform.position, spostamento, Color.red);
        //Debug.DrawRay(this.transform.position, vettoredirezione, Color.red);
        //Debug.DrawRay(Vector3.zero, pianeta.TransformDirection(this.transform.position + vettoredirezione), Color.green);
        RaycastHit hit;
        //Debug.DrawRay(pianeta.position, (((transform.position - pianeta.position) + vettoredirezione)*2), Color.black);
        Ray raggio = new Ray(pianeta.position,(transform.position - pianeta.position) + vettoredirezione);

        /*if(Physics.Raycast(raggio, out hit))
        {
            if(hit.collider != null)
            {
                Debug.Log(hit.collider);
                //Debug.DrawRay(pianeta.position, hit.point, Color.red);
                Debug.DrawRay(raggio.origin, raggio.direction, Color.red);
            }
        }*/

        // Vector3 posizionprova = Vector3.MoveTowards(transform.position, target.transform.position, .05f);
        // posizionprova.y = 0;
        //this.transform.Translate(spostamento.normalized * Time.deltaTime * 5f);
        Vector3 diff = target.position - this.transform.position;
        
        float mag = diff.magnitude;
        if (mag > 1.2f)
        {


            this.transform.LookAt(target, transform.up);
            Vector3 prova = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            this.transform.position = prova;

            /* int vaisinistra = Random.Range(0, 2);
             if (vaisinistra == 1)
             {
                 Debug.Log("Entro");
                 this.transform.Translate(new Vector3(1f, 0f, 0f)* Time.deltaTime);
                 Debug.DrawRay(this.transform.position, (new Vector3(1f, 0f, 0f)), Color.blue);
             }
         }*/
        }   
        //this.transform.LookAt(target);
        //this.transform.Translate(new Vector3(1,0,1).normalized * Time.deltaTime * 5f);

    }
}
