using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{

    public float speed = 6f;
    CharacterController characterController;
    public float jumpSpeed = 600f;
    private float gravity = 5f;
    private float jumpforce = 10f;
    public Camera cam;
    public Transform camTransform;
    float f;

    bool isGrounded;
    private Vector3 movement;
    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
        camTransform = cam.transform;
    }

    void FixedUpdate()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    movement.y = jumpSpeed;
        //}
        //  movement.y -= gravity * Time.deltaTime;

        //// Move the controller
        ////characterController.Move(movement * Time.deltaTime);

        //movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, 0, v);
    }

    void Move(float h, float j, float v)
    {
        movement = new Vector3(h, 0, v);

        //Rotera boll efter kaverafv
       // Quaternion rotation = Quaternion.Euler(, currentY, 0);

        //movement.normalized();
        playerRigidbody.AddForce(movement * speed);
        playerRigidbody.MovePosition(transform.position + movement);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(0, jumpSpeed, 0);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
        else
            isGrounded = false;
    }
}
