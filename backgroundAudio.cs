using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundAudio : MonoBehaviour
{
    public AudioSource[] sounds;
    public int currCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        sounds[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(caption.pauseCount != currCount){
             sounds[currCount].Stop();
             currCount = caption.pauseCount;
             sounds[currCount].Play();
        }
    }
}
