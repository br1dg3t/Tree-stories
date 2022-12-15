using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class caption : MonoBehaviour
{
    public string[] captions;
    private TMP_Text cap;
    private int count = 0;
    private float waitTime;
    public float regWait;
    public float longWait;
    public Image bgcolor;
    public AudioSource sound;
    private TextMeshPro textMesh;
    public GameObject bg;
    private RectTransform rectTransform;
    public Image character;
    public static bool charOn = false;
    public static bool pauseNow = false;
    public static int pauseCount = 0;
    public static int assetCount =  0;
    // Start is called before the first frame update
    void Start()
    {
        cap = GetComponent<TMP_Text>();
        textMesh = GetComponent<TextMeshPro>();
        bgcolor.enabled = true;
        StartCoroutine(nextCaption());
        waitTime = regWait;
        sound = GetComponent<AudioSource>();
        character.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator nextCaption(){
        rectTransform = bgcolor.GetComponent<RectTransform>();
        string s = "start";
        while(s!="end"){
            s = captions[count];
            if(s=="end"){
                character.enabled = false;
                charOn = false;
            }
            else if(s=="pause" || s=="switch" || s=="asset"){
                character.enabled = false;
                charOn = false;
                bg.transform.localScale = new Vector3(0f,0f,0f); 
                waitTime = longWait;
                cap.text = "";
                if(s=="switch"){
                    pauseCount++;
                    assetCount++;
                }
                if(s=="asset"){
                    assetCount++;
                }
                Invoke("charEnter",longWait);
            }else{
                character.enabled = true;
                if(s.Length<15){
                    bg.transform.localScale = new Vector3(s.Length*0.035f,1f,1f);
                }else{
                    bg.transform.localScale = new Vector3(s.Length*0.032f,1f,1f); 
                }
                bgcolor.enabled = true;
                StartCoroutine(typeCharacters(s));
                waitTime = regWait;
            }
            count++;
            if(count>captions.Length-1){
                count = 0;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator typeCharacters(string fullLine){
        for(int i = 0; i<fullLine.Length+1; i++){
            cap.text = fullLine.Substring(0,i);
            yield return new WaitForSeconds(0.05f);
        }
    }

    void charEnter(){
        character.enabled = true;
        charOn = true;
    }
}
