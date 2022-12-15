using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCollider : MonoBehaviour
{
    public static AudioSource soundfx;
    private bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        soundfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if(hasCollided==false){
            soundfx.Play();
         }
        hasCollided = true;
    }
}
