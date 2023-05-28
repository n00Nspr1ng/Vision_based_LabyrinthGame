using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapControl : MonoBehaviour
{
    private Rigidbody mapRb;
    //private int count;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        mapRb = this.GetComponent<Rigidbody>();
        startPos = mapRb.position;
        //count = 0;

    }
    void Update(){
    
    }

    
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Finish")){
            resetGameState();
           // Debug.Log("You Win!!");
        }
    }
    void resetGameState(){
        //count = 0;
        //reset
        mapRb.position = startPos;
        mapRb.velocity = Vector3.zero;
        mapRb.angularVelocity = Vector3.zero;
    }
}
