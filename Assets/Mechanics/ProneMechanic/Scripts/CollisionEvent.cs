using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// this script creates a collision event(later set) and makes it equal to the current event
/// also creates an action to invoke the event
/// </summary>
public class CollisionEvent : MonoBehaviour
{
    public static CollisionEvent current; //evidence of using Unity Events
    private void Awake()
    {
        current = this; //even is equal to whatever is set to 'current event'
    }
    public event Action onTriggerEnter; //evidence of using actions
    public void OnBoxTriggerEnter()
    {
        onTriggerEnter();
    }
}
