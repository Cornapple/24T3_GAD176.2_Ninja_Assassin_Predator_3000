using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpottedUI : MonoBehaviour
{
    public bool triggerSpotted;

    [SerializeField] private TextMeshProUGUI UI_Spotted;

    private void Start()
    {
        if (UI_Spotted == null)
        {
            UI_Spotted = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (triggerSpotted)
        {
            Debug.Log("UI Should be SPOTTED");

            UI_Spotted.text = "SPOTTED";

        }
        if (!triggerSpotted)
        {
            UI_Spotted.text = "HIDDEN";
        }
    }
}
