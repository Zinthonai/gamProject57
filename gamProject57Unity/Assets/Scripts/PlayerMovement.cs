using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    public float maxSpeed;
    public float jumpPower;
    
    public float rotationSpeed;

    GameObject playerObj;
    Rigidbody rb;
    Animator playerAnimator;

    public Camera mainCamera;

    Quaternion velocityAngle;
    Vector3 velocityAngleEuler;
    Quaternion angleToRotateTo;

    float xzVelMag;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //Movement

        //Finds the speed in the xy directions - jumping can be faster than maxSpeed
        xzVelMag = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z);
        //Debug.Log(xzVelMag);
        
        if(xzVelMag < maxSpeed)
        {
            if(Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, 0, 1) * speed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, 0, -1) * speed);
            }
            if(Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-1, 0, 0) * speed);
            }
            if(Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(1, 0, 0) * speed);
            }
        }

        if(rb.velocity.magnitude > 0)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }


        //Edits speed to change as speed of player changes
        playerAnimator.speed = (rb.velocity.magnitude) / maxSpeed;
            

        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpPower, ForceMode.Impulse);
        }


        //Rotate player to the velocity vector
        if(rb.velocity.magnitude > 0.1f)
        {
            velocityAngle = Quaternion.LookRotation(rb.velocity);
            velocityAngleEuler = velocityAngle.eulerAngles;

            angleToRotateTo = Quaternion.Euler(0, velocityAngleEuler.y, 0);
            
            //apply character rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, angleToRotateTo, rotationSpeed);
        }

    }
}
