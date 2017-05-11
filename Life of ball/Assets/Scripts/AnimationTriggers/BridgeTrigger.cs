using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{


    public Animator buttonAnimator;
    public Animator bridgeAnimator;


    void Start()
    {
        buttonAnimator = GetComponent<Animator>();
      

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            buttonAnimator.Play("ButtonDown");
        }
    }

    void OnTriggerExit(Collider col)
    {
        buttonAnimator.Play("ButtonUp");
        bridgeAnimator.Play("Fold");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("q"))
        {
            buttonAnimator.Play("ButtonDown");
        }

        if (Input.GetKeyDown("e"))
        {
            buttonAnimator.Play("ButtonUp");
        }

    }
}
