using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private BoxController boxController;
    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
        CollisionEvent.current.OnBoxTriggerEnter();
        Debug.LogWarning("Trigger Area Triggered");  
    }
}
