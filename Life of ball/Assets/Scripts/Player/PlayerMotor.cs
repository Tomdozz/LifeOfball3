using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    public float speed = 6f;
    public float jumpForce = 600f;

    private CharacterController controller;

    //private float verticalVelocity;
    //private float horizontalVelocity;
    //private float zVelocity;
    private float gravity = 14.0f;
    float h, v;
    bool isGrounded;


    Vector3 moveVector;
    Rigidbody playerRigidbody;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Move(h, 0, v);
    }

    void Move(float h, float j, float v)
    {
        moveVector = new Vector3(h, 0, v);
        //moveVector = Camera.main.transform.TransformDirection(moveVector);
        moveVector = Camera.main.transform.TransformVector(moveVector);

        playerRigidbody.AddForce(moveVector * speed);
        //playerRigidbody.MovePosition(transform.position + moveVector);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(0, jumpForce, 0);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else
            isGrounded = false;
    }

}
