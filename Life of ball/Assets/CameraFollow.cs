using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;
    float distance = 10.0f;
    float currentX = 0f;
    float currentY = 0f;
    float sensitivityX = 0f;
    float sensitivityY = 0f;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;

        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY,0);
        camTransform.position = lookAt.position + rotation * dir;

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
       
        // transform.LookAt(player.transform);
    }
}
