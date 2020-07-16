using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gif : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] animatedImages;
    [SerializeField]
    private float speed;
    public Image animatedImgObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animatedImgObj.sprite = animatedImages[(int)(Time.time * speed) % animatedImages.Length];
    }
}
