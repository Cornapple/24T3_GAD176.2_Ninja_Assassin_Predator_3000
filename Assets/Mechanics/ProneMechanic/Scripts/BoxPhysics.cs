using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhysics : MonoBehaviour
{
    public GameObject box;
    public Physics physics;
    public Rigidbody rb;

    float ShootSpeed = 1000f;
    public bool boxIsActive = false;

    // Update is called once per frame
    public void ApplyForce() //evidence of physics
    {
        Debug.Log("Apply Force Has been Called");
        boxIsActive = true;
        rb = GetComponent<Rigidbody>();
        if(boxIsActive == true)
        {
            Debug.Log("Box is Active");
            rb.AddForce(Vector3.up * ShootSpeed);
            rb.useGravity = true;
        }    
    }
}
