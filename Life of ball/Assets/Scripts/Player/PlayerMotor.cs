using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;

    private float verticalVelocity;
    private float horizontalVelocity;
    private float zVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;

    Vector3 moveVector;

    public float speed = 6f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
     
    }

    private void Update()
    {
        horizontalVelocity = Input.GetAxis("Horizontal");
        zVelocity = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            
            verticalVelocity = -gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            
        }

        moveVector = new Vector3(horizontalVelocity * speed, verticalVelocity, zVelocity * speed);
        moveVector = Camera.main.transform.TransformDirection(moveVector);
        controller.Move(moveVector * Time.deltaTime);
    }
	
}
