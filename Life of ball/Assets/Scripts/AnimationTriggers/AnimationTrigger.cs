using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

    public Animator buttonAnimator;
    public Animator armsAnimator;
    public GameObject[] arms;




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
        foreach (GameObject g in arms)
        {
            armsAnimator = g.GetComponent<Animator>();
            armsAnimator.Play("ArmExtend");
            new WaitForSecondsRealtime(2);
        }
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
