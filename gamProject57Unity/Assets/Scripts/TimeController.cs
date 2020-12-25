using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject playerObj;
    Rigidbody rb;

    PlayerMovement playerMovementScript;

    private float fixedDeltaTime;

    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = playerObj.GetComponent<PlayerMovement>();
        rb = playerObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float velocityNormalized = rb.velocity.magnitude/playerMovementScript.maxSpeed;
        if(Input.GetKey(KeyCode.T))
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        //Time.timeScale = velocityNormalized + 0.1f;

        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
