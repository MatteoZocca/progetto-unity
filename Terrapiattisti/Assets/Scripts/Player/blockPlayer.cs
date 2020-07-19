using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockPlayer : MonoBehaviour
{
    public Transform metarig;
    public float raggioCattura;
    TouchController touch;
    public Checker checker;
    private bool checkerDone;
    public GameObject joystickdestro;
    private GameObject player;
    private Image rjoystick;
    // Start is called before the first frame update
    void Start()
    {
        rjoystick = joystickdestro.GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        touch = player.GetComponent<TouchController>();
        checker.OnSkillCheckDone.AddListener(checkDone);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkerDone)
            return;

        Collider[] hitColliders = Physics.OverlapSphere(metarig.position, raggioCattura);
        
        foreach (Collider coll in hitColliders) {
            if (coll.transform.tag == "mani" && touch.fermate != true)
            {
                    rjoystick.enabled = false;
                    touch.fermate = true;
                    checker.gameObject.SetActive(true);
            }
        }
    }

    private void checkDone(bool done)
    {
        if (done)
        {
            checkerDone = true;
            checker.gameObject.SetActive(false);
            touch.fermate = false;
            rjoystick.enabled = true;
            StartCoroutine(staiFermo());

        }
        //do nothing
    }

    IEnumerator staiFermo()
    {
        yield return new WaitForSeconds(3f);
        checkerDone = false;

    }
    

}
