using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(trailClone());
    }

    // Update is called once per frame
    void Update()
    {
    }

     IEnumerator trailClone(){
        while(true){
            if(gameObject.name.Contains("Clone") == false){
                Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(0,0,0));
            } 
            yield return new WaitForSeconds(2f);
        }
    }
}
