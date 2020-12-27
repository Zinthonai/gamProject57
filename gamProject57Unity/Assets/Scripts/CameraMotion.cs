using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{

    public GameObject targetObj;
    public GameObject playerObj;
    Camera mainCamera;

    public Vector3 cameraPosition;
    public Vector3 cameraRoomPosition;
    public float cameraFollowSpeed;

    bool playerIsInRoom;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        //Detect if we are in a room
        RaycastHit hit;
        // Does the ray intersect any objects with 'Room' tag
        if (Physics.Raycast(playerObj.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(playerObj.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if(hit.collider.gameObject.tag == "Room")
            {
                playerIsInRoom = true;
                targetObj = hit.collider.gameObject;
                
            }
            else
            {
                targetObj = playerObj;
                playerIsInRoom = false;
            }
        }
        //Move the camera to follow with delay
        float x = targetObj.transform.position.x;
        float z = targetObj.transform.position.z;

        if(playerIsInRoom)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(x, 0, z) + cameraRoomPosition, cameraFollowSpeed/100);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(x, 0, z) + cameraPosition, cameraFollowSpeed/100);
        }
        
    }
}
