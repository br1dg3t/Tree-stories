using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.WorldToScreenPoint(transform.position).x>1920){
            transform.position = cam.ScreenToWorldPoint(new Vector3(0f, cam.WorldToScreenPoint(transform.position).y, cam.WorldToScreenPoint(transform.position).z));
        }
        else if(cam.WorldToScreenPoint(transform.position).x<0){
            transform.position = cam.ScreenToWorldPoint(new Vector3(1920f, cam.WorldToScreenPoint(transform.position).y, cam.WorldToScreenPoint(transform.position).z));
        }
        if(cam.WorldToScreenPoint(transform.position).y>1080){
            transform.position = cam.ScreenToWorldPoint(new Vector3(cam.WorldToScreenPoint(transform.position).x, 0f, cam.WorldToScreenPoint(transform.position).z));
        } else  if(cam.WorldToScreenPoint(transform.position).y<0){
            transform.position = cam.ScreenToWorldPoint(new Vector3(cam.WorldToScreenPoint(transform.position).x, 1080f, cam.WorldToScreenPoint(transform.position).z));
        }
    }
}
