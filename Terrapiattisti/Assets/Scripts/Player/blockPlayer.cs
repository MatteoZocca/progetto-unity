using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPlayer : MonoBehaviour
{
    public Transform metarig;
    public float raggioCattura;
    TouchController touch;
    // Start is called before the first frame update
    void Start()
    {
        touch = this.GetComponent<TouchController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(metarig.position, raggioCattura);
        foreach (Collider coll in hitColliders) {
            if (coll.transform.tag == "mani")
            {
                    touch.fermate = true;            
            }
        }
    }
}
