using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private Vector3 vettoredirezione;
    private Vector3 vettorePosizione;
    public Transform pianeta;
    private Animator animator;
   TouchController touch;

    private float speed;
    System.Random rdn;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        animator = this.GetComponent<Animator>();
        speed = Random.RandomRange(3f, 4f);

        touch = GameObject.FindGameObjectWithTag("Player").GetComponent<TouchController>();

    }

    public void GravityOggetto(Transform body)
    {
        Vector3 gravityUp = (body.position - pianeta.position).normalized; //differenza tra posizione attuale elemento e vettoreTerra
        Vector3 positionBody = body.up; // ritorna il vettore (0,1,0) relativo alla rotazione dell'oggetto, ovvero l'asse Y rispetto al GameObject

        body.GetComponent<Rigidbody>().AddForce(Attractor.gravity * gravityUp); // aggiunge forza di gravità all'oggetto passato

        Quaternion targetRotation = Quaternion.FromToRotation(positionBody, gravityUp) * body.rotation; //ruota l'oggetto
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {


    

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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Corsa"))
            this.transform.LookAt(target, transform.up);

        float mag = diff.magnitude;
        if (mag > 1.2f)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isGrabbing", true);
            Vector3 prova;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Corsa"))
            {
                 prova = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                 this.transform.position = prova;

            }



            /* int vaisinistra = Random.Range(0, 2);
             if (vaisinistra == 1)
             {
                 Debug.Log("Entro");
                 this.transform.Translate(new Vector3(1f, 0f, 0f)* Time.deltaTime);
                 Debug.DrawRay(this.transform.position, (new Vector3(1f, 0f, 0f)), Color.blue);
             }
         }*/
        }
        else
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isGrabbing", false);
            StartCoroutine(Aspetta());

        }
        //this.transform.LookAt(target);
        //this.transform.Translate(new Vector3(1,0,1).normalized * Time.deltaTime * 5f);
        this.GravityOggetto(this.transform);

    }


    IEnumerator Aspetta()
    {
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
    }
}
