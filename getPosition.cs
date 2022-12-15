using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPosition : MonoBehaviour
{
    private static GameObject player;
    //private static float scatterClose= 250f;
    //private static float scatterFar = 250f;
    private static float scatterHorizontal = 35f;
    private static float verticalPosition = -100f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(player.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 setStart(){
        return new Vector3(Random.Range(-scatterHorizontal,scatterHorizontal), verticalPosition, Random.Range(-scatterHorizontal,scatterHorizontal));
    }

    public static Vector3 getPos(){
        return new Vector3(player.transform.position.x + (250*move.moveDirection.x)+Random.Range(-70,70), -4, player.transform.position.z + (250*move.moveDirection.z)+Random.Range(-70,70));
    }

    public static string getDirection(){
        if(move.moveDirection.x > 0){ // (1, 0) RIGHT
            return "right";
        } else if (move.moveDirection.x < 0){ //(-1, 0) LEFT
            return "left";
        } else if (move.moveDirection.z > 0){ //(0, 1) FORWARD
            return "forward";
        } else if (move.moveDirection.z <0){ //(0, -1) BACKWARD
            return "backward";
        } else{
            return "null";
        }
    }
}
