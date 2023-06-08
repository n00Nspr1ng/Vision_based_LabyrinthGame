using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class tilt : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 currentRot;
    private int tilt_thresh;
    private bool debug;
    private HelloRequester _helloRequester;
    //private bool RLinput;

    // Start is called before the first frame update
    void Start()
    {    
        tilt_thresh = 15; // use this value to control the maximum rotation of the board
        debug = false;
        _helloRequester = new HelloRequester();
        _helloRequester.Start();
        //RLinput = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   currentRot = GetComponent<Transform>().eulerAngles;
        

        if ((Input.GetAxis("Horizontal") > .2) || Input.GetKeyDown(KeyCode.D))
        {
            if(currentRot.z <= (360-tilt_thresh) && currentRot.z >= 180){}
            else transform.Rotate(0,0,-0.1f);
            if(debug==true){
                Debug.Log("Right button clicked");
                Debug.Log(currentRot.z);
            }
            
        }
        else if ((Input.GetAxis("Horizontal") < -.2) || Input.GetKeyDown(KeyCode.A))
        {
            if(currentRot.z >= tilt_thresh && currentRot.z <= 180){}
            else transform.Rotate(0,0,0.1f);
            if(debug==true){
                Debug.Log("Left button clicked");
                Debug.Log(currentRot.z);
            }
        }
        if ((Input.GetAxis("Vertical") > .2)|| Input.GetKeyDown(KeyCode.W))
        {
            if(currentRot.x >= tilt_thresh && currentRot.x <= 180){}
            else  transform.Rotate(0.1f,0,0); //up down is flipped
            if(debug==true){
                Debug.Log("Up button clicked");
                Debug.Log(currentRot.x);
            }
        }
        else if ((Input.GetAxis("Vertical") < -.2)|| Input.GetKeyDown(KeyCode.S))
        {
            if(currentRot.x <= (360-tilt_thresh) && currentRot.x >= 180){}
            else transform.Rotate(-0.1f,0,0);
            if(debug==true){
                Debug.Log("Down button clicked");
                Debug.Log(currentRot.x);
            }
        }
        if(debug == true) Debug.Log(currentRot);
    }
    

}
