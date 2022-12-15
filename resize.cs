using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resize : MonoBehaviour
{
    private float randNum;
    public AudioSource sound;
    private Rigidbody rb;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(newSize());
        sound = GetComponent<AudioSource>();
        rb.drag = 10f;
        rb.mass=500f;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator newSize(){
        rb = GetComponent<Rigidbody>();
        while(count<12){
            randNum = Random.Range(0,250);
            if(randNum<5 && gameObject.name.Contains("Clone")){
                sound.Play();
                float multiplier = Random.Range(3f,8f);
                transform.localScale = new Vector3(transform.localScale.x *multiplier, transform.localScale.y *multiplier, transform.localScale.z *multiplier);
                transform.position = new Vector3(Random.Range(-40f,30f), 0, Random.Range(-20f,20f));
                rb.drag = 5f;
                rb.mass=30f;
                gameObject.tag = "big";
                Invoke("delete", 15.0f);
            }else if(randNum<100 && gameObject.name.Contains("Clone")){
                sound.Play();
                rb.drag = 0f;
                rb.mass=0f;
                Invoke("delete", 300.0f);
            }
            count++;
            yield return new WaitForSeconds(30f);
        }
    }

    void delete(){
        Destroy(gameObject);
    }
}
