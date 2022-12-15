using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overlayTrigger : MonoBehaviour
{
    public float timeOn;
    public float timeOff;
    private bool onNow = false;
    private bool wasOn = false;
    private Image image;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        image.enabled = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!wasOn && Time.unscaledTime>timeOn){
            image.enabled = true;
            onNow = true;
            anim.Play("swirl");
        }if (onNow && Time.unscaledTime>timeOff){
            image.enabled = false;
            wasOn = true;
            onNow = false;
        }
    }
}
