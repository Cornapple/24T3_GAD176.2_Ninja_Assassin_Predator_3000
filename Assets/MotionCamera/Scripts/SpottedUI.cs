using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This script is used to enable a UI to detect camera triggers (Whether or not the player has been spotted)
/// </summary>
public class SpottedUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI UI_Spotted; // textmeshpro to display hidden/spotted status

    public List<GameObject> MotionCamerasInScene = new List<GameObject>(); // list for storing camera objects

    private void Start()
    {
        if (UI_Spotted == null) // checks for null
        {
            UI_Spotted = GetComponentInChildren<TextMeshProUGUI>(); // attaches textmeshpro to variable
        }
    }

    private void Update()
    {
        if (MotionCamerasInScene.Count == 0) // if there are no motion cameras in the list, player is "HIDDEN"
        {
            UI_Spotted.text = "HIDDEN";
        }
        else // if there are motion cameras in the list, player is "SPOTTED"
        {
            UI_Spotted.text = "SPOTTED";
        }

    }
}
