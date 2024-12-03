using Stealth.Framework.Motion.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;


#region Script LO's
///aims for this script: cover basic scripting needs: Pascal/camel case, conventions, 
///debugging, multiple functions, multiple classes, commenting, folder tructure,  <summary>
///serialized field, use of geometry and vector
///
///potentually can be used for: singe responcibility, inheritance, use of namespaces, protected keyword
#endregion
public class ProneController : CorneliusMovementController
{
    //call camera trigger script
    private CameraTrigger cameraTrigger;

    //references player gameobject
    [SerializeField] private GameObject player;

    //refers to the detection script and mechanic
    public DetectionController detectionController;

    private bool playerIsProne;
    private bool pronePlayerSpeed;
    private float newPlayerSpeed = 1.5f;

    public TextMeshProUGUI proneText;

    void Start()
    {

        Debug.Log("Script is declared = " + detectionController);
        //detectionController.enabled = false;
        playerIsProne = false;

        //indicates the jump from CorneliusMovementController to ProneController
        Debug.Log("ProneController script has been called");
        pronePlayerSpeed = false;
        detectionController = null;

        if (cameraTrigger != null)
        {
            cameraTrigger.enabled = true;
        }
    }

    private new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift)/* && groundedPlayer*/)
        {
            // call the GoProne method
            GoProne();
        }

        if (pronePlayerSpeed == true && playerIsProne == true)
        {
            playerSpeed = newPlayerSpeed;
        }
    }

    // Update is called once per frame
    public void GoProne()
    {
        playerIsProne = true;  
        Debug.Log("GoProne method has been called from " + gameObject.name);
        proneText.SetText("You have gone prone");

        if (playerIsProne == true)
        {
            //calls the detectioncontroller script
            if (detectionController != null)
            {
                detectionController.enabled = true;
                detectionController.Detect();
                Debug.Log("Detect method has been called");
            }



            Debug.Log("Player is Prone");
            // transform player to lower level from third person controller
            player.transform.localScale = new Vector3(0, 0.5f, 0);

            //diactivates enemies ability to see the player (probably with another script called here)
            //trigger camera somehow needs to be disabled
            if (cameraTrigger == true)
            {
                cameraTrigger.enabled = false;
            }
            Debug.Log("Camera Trigger is disabled");
           
            // slows player down
            pronePlayerSpeed = true;
            if (playerIsProne == true)
            {
                Debug.Log("playerIsProne == true");
            } 
        }
    }
    //abstract method, changes player speed

}
