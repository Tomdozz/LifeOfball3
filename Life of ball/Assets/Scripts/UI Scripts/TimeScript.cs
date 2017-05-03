using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public string ellapsedTime;
    Text timeText; 
    DateTime time;
    float gameTime;
	// Use this for initialization
	void Start () {
        timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
        ellapsedTime = gameTime.ToString();
        int timer = (int)gameTime;
        timeText.text = "Time left: "+timer.ToString();//ellapsedTime;
		
	}
}
