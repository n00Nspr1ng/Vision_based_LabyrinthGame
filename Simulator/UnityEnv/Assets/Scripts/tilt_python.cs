using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class tilt_python : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 currentRot;
    private int tilt_thresh;
    private bool debug;
    private bool test;
    // private HelloRequester _helloRequester;
    //private bool RLinput;
    
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    Vector3 receivedPos = Vector3.zero;
    // string receivedCnt = "";
    string cntReceived = "";
    int c_idx = 0;
    bool running;

    // Start is called before the first frame update
    void Start()
    {    
        tilt_thresh = 15; // use this value to control the maximum rotation of the board
        debug = false;
        // _helloRequester = new HelloRequester();
        // _helloRequester.Start();
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();        
        //RLinput = true;
        //test = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   currentRot = GetComponent<Transform>().eulerAngles;
        

        if ((Input.GetAxis("Horizontal") > .2) || Input.GetKeyDown(KeyCode.D) || receivedPos[2] < -0.01)
        {
            if(currentRot.z <= (360-tilt_thresh) && currentRot.z >= 180){}
            else transform.Rotate(receivedPos);
            if(debug==true){
                Debug.Log("Right button clicked");
                Debug.Log(currentRot.z);
            }
            
        }
        else if ((Input.GetAxis("Horizontal") < -.2) || Input.GetKeyDown(KeyCode.A) || receivedPos[2] > 0.01)
        {
            if(currentRot.z >= tilt_thresh && currentRot.z <= 180){}
            else transform.Rotate(receivedPos);
            if(debug==true){
                Debug.Log("Left button clicked");
                Debug.Log(currentRot.z);
            }
        }
        if ((Input.GetAxis("Vertical") > .2)|| Input.GetKeyDown(KeyCode.W) || receivedPos[0] > 0.01)
        {
            if(currentRot.x >= tilt_thresh && currentRot.x <= 180){}
            else  transform.Rotate(receivedPos);//0.1f,0,0); //up down is flipped
            if(debug==true){
                Debug.Log("Up button clicked");
                Debug.Log(currentRot.x);
            }
        }
        else if ((Input.GetAxis("Vertical") < -.2)|| Input.GetKeyDown(KeyCode.S) || receivedPos[0] < -0.01)
        {
            if(currentRot.x <= (360-tilt_thresh) && currentRot.x >= 180){}
            else transform.Rotate(receivedPos);
            if(debug==true){
                Debug.Log("Down button clicked");
                Debug.Log(currentRot.x);
            }
        }
        if(debug == true) Debug.Log(currentRot);
    }
    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running)
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---receiving Data from the Host----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string

        if (dataReceived != null)
        {
            //---Using received data---
            // Debug.Log(dataReceived);
            c_idx = dataReceived.IndexOf("c");
            // Debug.Log(c_idx);
            cntReceived = dataReceived[(c_idx+1)..];
            dataReceived = dataReceived[..c_idx];
            Debug.Log(cntReceived);
            // if(int.Parse(cntReceived.Substring(1,1)) == int.Parse("c")){
            //     print(1);
            //     receivedCnt = dataReceived[1..];
            //     Debug.Log(receivedCnt);
            // }
            // else{
                //print(dataReceived[0]);
                receivedPos = StringToVector3(dataReceived); //<-- assigning receivedPos value from Python
            // }
            // print("received pos data, and moved the Cube!");

            //---Sending Data to Host----
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes(cntReceived); //Converting string to byte data
            //byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
    }

    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
     

}
