using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public int count;
    private Transform mapRb;
    public static Vector3 startPos;
    //public static bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
        mapRb = GameObject.Find("maze").GetComponent<Transform>();
        startPos = playerRb.position;
        count = 0;

    }
    void Update(){
    
    }

    
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Finish")){
            resetGameState();
            count++;
            Debug.Log("You win!!");
            
        }
    }
    void resetGameState(){
        //count = 0;
        //reset
        playerRb.position = startPos;
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        mapRb.rotation = Quaternion.identity;
    }
}
