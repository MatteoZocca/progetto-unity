using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damagePlayer : MonoBehaviour
{
    public Transform testa;
    public float raggioCattura;
    private GameObject player;
    private GameObject lifebar;
    public float danno;
    TouchController touch;
    private Slider slider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lifebar = GameObject.Find("lifebar");
        touch = player.GetComponent<TouchController>();
        slider = lifebar.GetComponent<Slider>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(testa.position, raggioCattura);
        foreach (Collider coll in hitColliders)
        {
            if (coll.transform.tag == "cartello")
            {
                slider.value -= danno;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(testa.position, raggioCattura);
    }
}
