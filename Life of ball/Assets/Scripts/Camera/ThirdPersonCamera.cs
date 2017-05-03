using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public Transform lookAt;
    public Transform camTransform;
     
    float Y_ANGLE_MAX = 50.0f;
    float Y_ANGLE_MIN = 0.0f;

    private Camera cam;
    float distance = 3.0f;
    float currentX = 0f;
    float currentY = 0f;
    float sensitivityX = 0f;
    float sensitivityY = 0f;

    public RaycastHit hit;
    float distanceOffset;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;

    }

    void Update()
    {
        offset = transform.position - player.transform.position;
        hit = new RaycastHit();

        if (Physics.Raycast(player.transform.position, offset, out hit, distance + 0.5f))
        {
            //Debug.DrawLine(player.transform.position,hit.point, Color.red);

            distanceOffset = distance - hit.distance + 0.8f;
            distanceOffset = Mathf.Clamp(distanceOffset, 0, distance);
        }
        else
        {
            distanceOffset = 0;
        }
        currentY += Input.GetAxis("Mouse X");
     currentX -= Input.GetAxis("Mouse Y");
        //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance + distanceOffset);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        camTransform.position = rotation * dir + lookAt.position;
        camTransform.LookAt(lookAt.position);
        Debug.DrawLine(lookAt.position, camTransform.position, Color.blue);


        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;

        // transform.LookAt(player.transform);
    }
}
