using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public float jumpPower;
    public float maxSpeed;

    
    

    public GameObject characterModelObj;
    public Camera mainCamera;

    public float characterRotationSpeed;
    Quaternion velocityAngle;
    Vector3 velocityAngleEuler;
    Quaternion angleToRotateTo;


    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = characterModelObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if(rb.velocity.magnitude < maxSpeed)
        {
            if(Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, 0, 1) * speed);
                playerAnimator.SetBool("isRunning", true);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, 0, -1) * speed);
                playerAnimator.SetBool("isRunning", true);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-1, 0, 0) * speed);
                playerAnimator.SetBool("isRunning", true);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(1, 0, 0) * speed);
                playerAnimator.SetBool("isRunning", true);
            }
            else
            {
                playerAnimator.SetBool("isRunning", false);
            }
        }
            

        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpPower, ForceMode.Impulse);
        }


        //Rotate model with velocity vector

        //get angle of the velocity
        Debug.Log(rb.velocity.magnitude);
        if(rb.velocity.magnitude > 0.1f)
        {
            velocityAngle = Quaternion.LookRotation(rb.velocity);
            velocityAngleEuler = velocityAngle.eulerAngles;

            angleToRotateTo = Quaternion.Euler(0, velocityAngleEuler.y, 0);
            
            //apply character rotation
            characterModelObj.transform.rotation = Quaternion.Slerp(characterModelObj.transform.rotation, angleToRotateTo, characterRotationSpeed);
        }

    }
}
