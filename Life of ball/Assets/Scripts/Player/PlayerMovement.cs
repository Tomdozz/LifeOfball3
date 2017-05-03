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
    RaycastHit hit;
    Vector3 direction;
    float distance = 0.5f;

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
        direction = transform.position - new Vector3(0, 1, 0)*0.6f;
        
    }

    void Move(float h, float j, float v)
    {
        movement = new Vector3(h, 0, v);
        movement = Camera.main.transform.TransformDirection(movement);

        //Rotera boll efter kaverafv
        // Quaternion rotation = Quaternion.Euler(, currentY, 0);

        //movement.normalized();

        Debug.DrawLine(transform.position, direction, Color.red);

        playerRigidbody.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Physics.Raycast(transform.position, direction, 0.5f) == true)
            {
                playerRigidbody.AddForce(0, jumpSpeed, 0);
            }
        }
    }

    bool OnGround()
    {
        hit = new RaycastHit();
        Debug.DrawLine(playerRigidbody.transform.position,Vector3.down, Color.red);
        if (Physics.Raycast(playerRigidbody.transform.position, Vector3.down, out hit, 0.1f))
        {
            isGrounded = true;
            return isGrounded;
        }

        isGrounded = false;
        return isGrounded;
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
