using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    

    public GameObject characterModel;
    public Camera mainCamera;

    public float characterRotationSpeed;
    Quaternion cameraAngle;
    Vector3 cameraAngleEuler;
    Quaternion angleToRotateTo;


    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed);
            playerAnimator.SetBool("isRunning", true);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed);
            playerAnimator.SetBool("isRunning", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed);
            playerAnimator.SetBool("isRunning", true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed);
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

        

        //Rotate model with Camera

        //get angle camera is looking at
        cameraAngle = Quaternion.LookRotation(mainCamera.transform.forward);


        cameraAngleEuler = cameraAngle.eulerAngles;


        angleToRotateTo = Quaternion.Euler(0, cameraAngleEuler.y, 0);

        //apply character rotation
        characterModel.transform.rotation = Quaternion.Slerp(characterModel.transform.rotation, angleToRotateTo, characterRotationSpeed);
        

        //Debug.Log(cameraAngle.eulerAngles);





    }
}
