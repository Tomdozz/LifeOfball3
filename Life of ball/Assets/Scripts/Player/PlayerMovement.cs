using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 6f;
    public Camera cam;
    public Transform camTransform;
  

  

    private Vector3 movement;
    Rigidbody playerRigidbody;
    RaycastHit hit;
    float distance;
    Vector3 direction;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    


    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(Vector3.down);
        Move(h, 0, v);
    }

    void Move(float h, float j, float v)
    {
        movement = new Vector3(h, 0, v);
        movement = Camera.main.transform.TransformDirection(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, direction, 1.5f))
            {
               //Debug.DrawLine(transform.position,hit.point, Color.red);

                playerRigidbody.AddForce(0, jumpSpeed, 0);

            }
        }

        playerRigidbody.AddForce(movement * speed);

    }


}
