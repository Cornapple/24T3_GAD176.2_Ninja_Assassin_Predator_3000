using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEnter;

    public BoxPhysics boxPhysics;
    public OnTriggerEnter triggerEnter;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(triggerEnter != null)
        { 
            boxPhysics.ApplyForce();
        }

    }
}
