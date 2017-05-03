using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 6f;
    public Camera cam;
    public Transform camTransform;
    float f;

    bool isGrounded;

    private Vector3 movement;
    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
        camTransform = cam.transform;

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

        //Rotera boll efter kaverafv
       // Quaternion rotation = Quaternion.Euler(, currentY, 0);

        //movement.normalized();
        playerRigidbody.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(0, jumpSpeed, 0);
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
