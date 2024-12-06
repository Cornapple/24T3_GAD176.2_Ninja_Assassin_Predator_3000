using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public static CollisionEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action onTriggerEnter;
    public void OnBoxTriggerEnter()
    {
        onTriggerEnter();
    }
}
