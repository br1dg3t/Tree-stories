using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicate : MonoBehaviour
{
    public GameObject prefab;
    public int count = 5;
    private int currCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name.Contains("Clone") == false){
            while(currCount<count){
                Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
                currCount++;     
            }
        }
    }
}
