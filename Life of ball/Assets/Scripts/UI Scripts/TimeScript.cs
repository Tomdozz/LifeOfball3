using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    public string ellapsedTime;
    public GameObject player;
    public GameObject button;
    bool play;
    Text timeText;
    DateTime time;
    float gameTime;


    // Use this for initialization
    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      //  if (Input.GetKeyDown(KeyCode.P))
      //  {
            play = true;
            gameTime += Time.deltaTime;
            ellapsedTime = gameTime.ToString();
            int timer = (int)gameTime;
            timeText.text = "Time: " + timer.ToString();//ellapsedTime;
       // }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {

        }
    }
}
