using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Information : MonoBehaviour
{   
    public TextMeshProUGUI scoreText;
    public int score;
    public string score_str;
    //TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Sphere").GetComponent<playerControl>().count;
        score_str = score.ToString();
        scoreText.text = "Score : " + score_str;
        // if(playerControl.finish == true){
        //     scoreText.text = playerControl.count;
        //     //score++;
        //     //playerControl.finish = false;
        //     //Debug.Log(playerControl.finish);
        // }
    }
}
