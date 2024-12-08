using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script causes the event to occur when the player gameObject enters the trigger area
/// </summary>
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
