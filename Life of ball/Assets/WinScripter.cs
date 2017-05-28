using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScripter : MonoBehaviour {


    public GameObject time;
    bool timerOn;

	// Use this for initialization
	void Start () {
       
        
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            timerOn = false;
        }
    }


    // Update is called once per frame
    void Update ()
    {
        if (timerOn == false)
        {
           //Hur når jag play-boolen i timern??
        }
	}
}
