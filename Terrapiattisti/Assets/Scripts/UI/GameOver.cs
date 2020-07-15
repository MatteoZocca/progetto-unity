using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Slider slider;
    public GameObject panel;
    public GameObject checkBar;
    private bool vivo;
    private Animator animator;
    private bool entrato = true;
    void Start()
    {
        slider = GameObject.Find("lifebar").GetComponent<Slider>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        vivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0 && vivo)
        {
            animator.SetBool("isMorto", true);
            vivo = false;
            checkBar.SetActive(false);
            
        
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animator.GetCurrentAnimatorStateInfo(0).IsName("Morto"))
        {
            if (entrato)
            {
                entrato = false;
                panel.SetActive(true);
                ParallaxGameManager.Instance.PauseGame();
            }
            
        }
    }
}
