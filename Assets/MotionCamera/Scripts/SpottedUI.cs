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
            UI_Spotted.text = "SPOTTED";
        }
        else
        {
            UI_Spotted.text = "HIDDEN";
        }
    }
}
