using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject chargingBar;
    private ChargingBar cb;
    public float raggioCattura;
    private Animator animazione;
    private bool entrato = false;
    public GameObject camera1;
    private List<GameObject> nemici;
    void Start()
    {
        cb = chargingBar.GetComponent<ChargingBar>();
        animazione = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cb.razzoDisponibile)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, raggioCattura);
            foreach (Collider coll in hitColliders)
            {
                if (coll.transform.tag == "Player" && entrato == false)
                {
                    foreach(GameObject nemico in GameObject.FindGameObjectsWithTag("nemico"))
                    {
                        if (nemico.GetComponent<Enemy>() != null)
                            nemico.GetComponent<Enemy>().finelivello = true;
                        
                        else if (nemico.GetComponent<Enemy2>() != null)
                                nemico.GetComponent<Enemy2>().finelivello = true;
                    }
                    GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("Main Camera").SetActive(false);
                    GameObject.Find("Astronauta").SetActive(false);
                    camera1.SetActive(true);                   
                    entrato = true;
                    animazione.SetBool("isPartenza", true);
                }
            }
        }

        if (animazione.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animazione.GetCurrentAnimatorStateInfo(0).IsName("Razzo|RazzoAction"))
        {
            GameObject.Find("ChargingBar").SetActive(false);
            GameObject.Find("Fixed Joystick").SetActive(false);
            GameObject.Find("Floating Joystick").SetActive(false);
            GameObject.Find("lifebar").SetActive(false);

            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, raggioCattura);
    }
}
