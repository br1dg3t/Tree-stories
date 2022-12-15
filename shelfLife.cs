using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelfLife : MonoBehaviour
{
    private float randNum;
    public AudioSource sound;
    private float timeMade;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeMade = Time.unscaledTime;
        sound = GetComponent<AudioSource>();
        StartCoroutine(expire());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator expire(){
        while(count<2){
            count++;
            if(gameObject.name.Contains("Clone")){
            float decider = Random.Range(0,Time.unscaledTime);
            if(decider<(Time.unscaledTime-timeMade)/2){
                sound.Play();
                Destroy(gameObject);
            }
        }
        yield return new WaitForSeconds(100f);
        }
    }

}
