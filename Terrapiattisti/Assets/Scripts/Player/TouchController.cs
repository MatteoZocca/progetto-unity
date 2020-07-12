using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Joystick ljoystick;
    public Joystick rjoystick;

    public Transform astronauta;
    private Animator animator;

    public float speed = 5;
    public float rotaspeed = 10f;
    public bool fermate = false;
    private Vector3 vettoreMovimento;
    private Vector3 forwardIniziale;
    
    // Start is called before the first frame update
    void Start() {
        if (astronauta == null)
            astronauta = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).transform;

        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        forwardIniziale = astronauta.forward;
    }

    // Update is called once per frame
    void Update()
    {

        vettoreMovimento = new Vector3(ljoystick.Horizontal, 0f, ljoystick.Vertical);
        Vector3 vettoreRelativoPlayer = transform.TransformDirection(vettoreMovimento); //trasforma il vettore locale in globale
        float angle = Vector3.SignedAngle(astronauta.forward, vettoreRelativoPlayer, this.transform.up);

        if(fermate != true)
        {
            rjoystick.StopAllCoroutines();
            this.transform.Translate(vettoreMovimento * speed * Time.deltaTime);
            this.transform.Rotate(0f, rjoystick.Horizontal * 2f, 0);
            TriggerAnimations();
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }


        if (vettoreMovimento != Vector3.zero)
            astronauta.Rotate(new Vector3(0f, angle, 0f) * Time.deltaTime * rotaspeed, Space.Self);

    }

    private void TriggerAnimations() {
        if (vettoreMovimento.x > 0.7 || vettoreMovimento.x < -0.7 || vettoreMovimento.z > 0.7 || vettoreMovimento.z < -0.7) {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
        }
        else if (vettoreMovimento.x == 0 && vettoreMovimento.z == 0) {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        else if (vettoreMovimento.x != 0 && vettoreMovimento.z != 0) {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }
    }
}