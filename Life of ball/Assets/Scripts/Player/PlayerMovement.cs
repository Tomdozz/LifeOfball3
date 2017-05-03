using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cameraMain;
    public Transform camTransform;
    public float speed = 6f;
    public float jumpForce = 6f;
    public bool isGrounded;
    public float distance = 0.25f;

    Vector3 movement;
    Vector3 direction;
    Rigidbody playerRigidbody;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        cameraMain = Camera.main;
        camTransform = cameraMain.transform;

    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, 0, v);

    }

    void Move(float h, float j, float v)
    {
        movement = new Vector3(h, 0, v);
        movement = Camera.main.transform.TransformDirection(movement);

        //Debug.DrawLine(transform.position, direction, Color.red);

        playerRigidbody.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GroundCheck();
            //if (isGrounded)
            //{
                playerRigidbody.AddForce(0, jumpForce, 0);

            //}

        }

    }

    public void GroundCheck()
    {
        if (isGrounded)
        {
            distance = 0.25f;
        }
        else
        {
            distance = 0.05f;
        }

        if (Physics.Raycast(transform.position - new Vector3(0, 0.55f, 0), -transform.up, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }




}
