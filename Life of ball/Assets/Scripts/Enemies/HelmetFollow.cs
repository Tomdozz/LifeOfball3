using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetFollow : MonoBehaviour {

    public GameObject Ball;       //Public variable to store a reference to the player game object

    Vector3 offset;
                                    // Use this for initialization
    void Start ()
    {
        offset = new Vector3(0, 0.3f, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Ball.transform.position + offset;
    }
}
