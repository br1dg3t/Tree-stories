using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Camera cam;
    public static AudioSource soundfx;
    public  AudioSource panelSound;
    private bool hasCollided = false;
    public GameObject panel;
    public static bool isActive = false;
    
    // Start is called before the first frame update
    void Start() 
    {
       panelSound = panel.GetComponent<AudioSource>();
         soundfx = GetComponent<AudioSource>();
          StartCoroutine(startSound());
          if(gameObject.name =="caterpillar"){
            isActive = true;
          }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false){
            panel.transform.position = new Vector3(960,540,0);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(hasCollided==false){
            //soundfx.Play();
            AudioSource other = collision.gameObject.GetComponent<AudioSource>();
            //other.Play();
            panel.transform.position = cam.WorldToScreenPoint(collision.transform.position);
            panel.SetActive(true);
            //panelSound.Play();
            if(collision.gameObject.tag =="big"){
                panel.transform.localScale = new Vector3(3f,3f,3f);
            }else{
                panel.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
            }
        }
        hasCollided = true;
    }

    IEnumerator startSound(){
        while(isActive == false){
            panel.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(10f);
        }
    }
}
