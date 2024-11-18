using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCameraSystem : MonoBehaviour
{
    [SerializeField] private Vector3 cameraHeadPosition;
    
    [SerializeField] private float cameraSpeed;

    [SerializeField] private bool maxRightRotation = false;

    private void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        if (maxRightRotation == false)
        {
            cameraHeadPosition = new Vector3(0, 20, 0);

            transform.Rotate(cameraHeadPosition * cameraSpeed * Time.deltaTime);

            
        }
       

    }
}
