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
    public Transform viewPoint; //the point from which the raycast shoots

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
            Debug.LogWarning("You have hit " + hit.collider.gameObject);
        }
        else
        {
            targetPoint = ray.GetPoint(100);
            Debug.Log("target point missed");
        }
        Vector3 directionOfView= targetPoint - viewPoint.position; // Evidence of Subtraction
    }
}
