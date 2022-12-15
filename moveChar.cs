using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveChar : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public Image character;
    private Animator charAnim;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
         StartCoroutine(reposition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator reposition(){
        charAnim = character.GetComponent<Animator>();
        while(true){
            Vector3 charPos = cam.WorldToScreenPoint(player.transform.position);
            if(charPos.x>1000){
                charPos = new Vector3(1800, charPos.y+400, charPos.z);
            }else if(charPos.y<100){
                charPos = new Vector3(charPos.x+800, 500, charPos.z);
            }
            else{
                charPos = new Vector3(charPos.x+800, charPos.y+400, charPos.z);
            }
            transform.position = charPos;
            playAnim();
            yield return new WaitForSeconds(5f);
        }
    }

    void playAnim(){
        //character.enabled = true;
        sound.Play();
        charAnim.Play("char_enter");
        charAnim.GetComponent<Animator>().Play("char_enter", -1, 0);
    }
}
