using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script sets the event to equal the OnBoxActive method, which applys upward force to the box when the trigger is entered
/// </summary>
public class BoxController : MonoBehaviour
{
    public Rigidbody rb;
    float ShootSpeed = 1000f; //sets the force at which the box moves
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        CollisionEvent.current.onTriggerEnter += OnBoxActive; //sets the current event to the OnBoxActive method
    }
    protected void OnBoxActive()
    { //applies force
        Debug.LogWarning("OnBoxActive Called");
        rb.AddForce(Vector3.up * ShootSpeed); //Evidence of physics
        rb.useGravity = true;
    }    
}
