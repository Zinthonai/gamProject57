using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementController : MonoBehaviour
{
    //Control tile movement
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                
                if(hit.collider.gameObject.tag == "Tile")
                {
                    Debug.Log("Hit a tile!!");
                    
                }

            }
        }
        


    }
}
