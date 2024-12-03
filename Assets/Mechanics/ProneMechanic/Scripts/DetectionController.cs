using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DetectionController : ProneController
{
    protected RaycastHit raycast;
    public GameObject player;
    public Camera mainCamera;

    public ProneController proneController;

    // Start is called before the first frame update
    void Start()
    {
        detectionController.enabled = false;
    }

    // Update is called once per frame
    public virtual void Detect()
    {
        Debug.Log("Camera Detector is active");
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            Debug.Log("traget point hit");
            Debug.Log(gameObject.name);
        }
        else
        {
            targetPoint = ray.GetPoint(100);
            Debug.Log("target point missed");
        }

        // object hit by raycast has to be shown in debug "enemy"
    }

    //public override void Detect()
    //{

    //}
}
