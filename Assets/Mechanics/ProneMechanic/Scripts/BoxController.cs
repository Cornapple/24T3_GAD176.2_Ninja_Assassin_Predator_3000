using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Rigidbody rb;
    float ShootSpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        CollisionEvent.current.onTriggerEnter += OnBoxActive;
    }

    // Update is called once per frame
    protected void OnBoxActive()
    {
        Debug.LogWarning("OnBoxActive Called");
        rb.AddForce(Vector3.up * ShootSpeed); //Evidence of physics
        rb.useGravity = true;
    }    
}
