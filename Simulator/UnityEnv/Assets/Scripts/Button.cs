using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnClickButton()
    {
        Debug.Log("Reset button Clicked!");
        GameObject.Find("Sphere").GetComponent<playerControl>().count = 0;

        GameObject.Find("maze").GetComponent<Transform>().rotation = Quaternion.identity;
        GameObject.Find("Sphere").GetComponent<Rigidbody>().position = playerControl.startPos;
        GameObject.Find("Sphere").GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameObject.Find("Sphere").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}