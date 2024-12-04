using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// this script uses raycasts to draw a line 
/// from the camera to what you are looking at and uses tags
/// and ui to tell you what you see (when in prone)
/// </summary>

public class DetectionController : ProneController
{
    protected RaycastHit raycast; //evidence of protected keyword
    //public GameObject player;
    public Camera mainCamera;

    public Transform viewPoint;

    //public ProneController proneController;

    // Start is called before the first frame update
    void Start()
    {
        //detectionController.enabled = false;
    }

    // Update is called once per frame
    public void Detect()
    {
        Debug.Log("Camera Detector is active");
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            Debug.Log("traget point hit");
            Debug.Log("You have hit " + tag);
        }
        else
        {
            targetPoint = ray.GetPoint(100);
            Debug.Log("target point missed");
        }
        Vector3 directionOfView= targetPoint - viewPoint.position; // Evidence of Subtraction

        //Vector3 directionofView = directionOfView + new Vector3(x, y, 0);

        // object hit by raycast has to be shown in debug "enemy"
    }

    //public override void Detect()
    //{

    //}
}
