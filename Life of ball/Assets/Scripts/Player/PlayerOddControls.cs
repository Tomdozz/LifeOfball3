﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOddControls : MonoBehaviour {

    bool pause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
		
	}
    void Pause()
    {

    }
}
