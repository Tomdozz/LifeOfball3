using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBridgeAnim : MonoBehaviour {

    public Animator bridgeAnim;
    public Animator buttonAnim;

	// Use this for initialization
	void Start () {

        bridgeAnim.enabled = false;
        buttonAnim.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    //void OnTriggerEnter()
    //{
    //    bridgeAnim.Play("Take 001");
    //    buttonAnim.Play("Take 001");
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BridgeButton")
        {
            bridgeAnim.StartPlayback();
            buttonAnim.StartPlayback();
        }
       
    }
}
