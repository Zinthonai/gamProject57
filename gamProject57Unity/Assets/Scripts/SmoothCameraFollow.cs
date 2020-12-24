using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    public GameObject targetObj;
    Camera mainCamera;

    public Vector3 customCameraPosition;
    public float cameraFollowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the camera to follow with delay

        float x = targetObj.transform.position.x;
        float z = targetObj.transform.position.z;
        transform.position = Vector3.Slerp(transform.position, new Vector3(x, 8.5f, z) + customCameraPosition, cameraFollowSpeed/100);
        
    }
}
