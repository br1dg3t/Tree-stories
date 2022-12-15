using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Camera cam;
    public Camera zoomCam;
    public GameObject cursor;
    public GameObject accelerate;
    public Image cursorImg;
    public Image accelerateImg;
    public float speed = 1f;
    public static Vector3 moveDirection;
    public float trailSpeed;
    private float xDirection;
    private float yDirection;
    public static GameObject currPrefab;
    public GameObject[] prefabs;
    public int currPrefabNum = 0;
    public static Vector3 prevPos;
    public float[] timeStamp;
    private int currTime;
    public Camera titleCam;
    public Canvas titleCard;
    public Canvas sprites;
    public Canvas captions;
    private bool unplayed = true;
    public AudioSource sound;
    private float stopTime;
    // Start is called before the first frame update
    void Start()
    {
        zoomCam.enabled = false;
        sound = GetComponent<AudioSource>();
        titleCard.enabled = true;
        titleCam.enabled = true;
        captions.enabled = false;
        sprites.enabled = false;
        currTime = 0;
        currPrefab = prefabs[0];
        StartCoroutine(trailClone());
        StartCoroutine(cursorTiming());
        accelerateImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursor.transform.position = cam.WorldToScreenPoint(transform.position);
        cursor.transform.rotation = Quaternion.Euler(moveDirection);
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        moveDirection = new Vector3(xDirection/3, 0f, yDirection);
        moveDirection.Normalize(); //"ensure it has magnitute of 1"
        transform.Translate(moveDirection * speed*getSpeed() * Time.deltaTime, Space.World);
        if(moveDirection != Vector3.zero){ //if button pressed
            unplayed = false;
           titleCard.enabled = false;
           titleCam.enabled = false;
           captions.enabled = true;
           sprites.enabled = true;
           transform.forward = moveDirection; 
        } //if nothing pressed
         else{
            if(unplayed==false){
                unplayed = true;
                stopTime = Time.unscaledTime;
                Invoke("title", 20.0f);
            }
         }
        if(caption.charOn){
            zoomCam.enabled = false;
            zoomCam.orthographicSize =Random.Range(2f,8f);;
        }else{
            zoomCam.enabled = true;
        }
    }

    public void title(){
        float compTime = Time.unscaledTime-20f;
        if(Mathf.Abs(stopTime-compTime)<0.2 && unplayed){
            captions.enabled = false;
            sprites.enabled = false;
            titleCard.enabled = true;
            titleCam.enabled = true;
        }
    }

    IEnumerator trailClone(){
        while(true){
            if(gameObject.name.Contains("Clone") == false){
                if(caption.assetCount != currPrefabNum){ //switch prefab
                    collision.isActive = true;
                    currPrefabNum++;
                    currTime++;
                    if(currPrefabNum == prefabs.Length){
                        currPrefabNum = 0;
                    }
                    if(currTime == timeStamp.Length){
                        currTime = 0;
                    }
                    currPrefab = prefabs[currPrefabNum];
                }
                if(prevPos != transform.position){
                  Instantiate(currPrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.Euler(0,getDirection(),0));
                }
                prevPos = transform.position;
            } 
            yield return new WaitForSeconds(trailSpeed);
        }
    }

    public float getSpeed(){
        float directionSum = Mathf.Abs(xDirection)+Mathf.Abs(yDirection);
        if(zoomCam.enabled){
            directionSum = 0.8f;
            //trailSpeed = 0.3f;
        }
        else if(directionSum==1f){
            directionSum=1.7f;
            //trailSpeed = 0.2f;
        }else if(directionSum>1f){
            directionSum=1f;
            //trailSpeed = 0.2f;
        }
        return directionSum;
    }

    public float getDirection(){       
            zoomCam.transform.position = new Vector3(transform.position.x, 16f, transform.position.z);
        if(moveDirection.x > 0){ // (1, 0) RIGHT 
            cam.transform.position = new Vector3(cam.transform.position.x+0.12f,cam.transform.position.y,cam.transform.position.z);  
            return 0f;
        } else if (moveDirection.x < 0){ //(-1, 0) LEFT
            cam.transform.position = new Vector3(cam.transform.position.x-0.12f,cam.transform.position.y,cam.transform.position.z);            
            return 180f;
        } else if (moveDirection.z > 0){ //(0, 1) FORWARD
            cam.transform.position = new Vector3(cam.transform.position.x,cam.transform.position.y,cam.transform.position.z+0.12f); 
            return 270f;
        } else if (moveDirection.z <0){ //(0, -1) BACKWARD
            cam.transform.position = new Vector3(cam.transform.position.x,cam.transform.position.y,cam.transform.position.z-0.12f); 
            return 90f;
        } else{
            return 0f;
        }
    }
    IEnumerator cursorTiming(){
        float waitTime = .8f;
        while(true){
            if(cursorImg.enabled){
                waitTime = 2.4f;
                cursorImg.enabled = false;
            }else{
                waitTime = .8f;
                cursorImg.enabled = true;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
