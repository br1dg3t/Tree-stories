using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class biblio : MonoBehaviour
{
    public float speed = 1f;
    static Vector3 resetPos = new Vector3(0f,0f,0f);
    private Vector3 move = new Vector3(-1,0,0);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveBib());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

     IEnumerator moveBib(){
         while(true){
             if (transform.position.x < 10600){
            transform.position = new Vector3(35900,-408,0);
            }
            transform.position += move * speed;
             yield return new WaitForSeconds(0.1f);
         }
     }
}
