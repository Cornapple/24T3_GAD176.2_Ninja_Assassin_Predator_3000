using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MotionCameraSystem : MonoBehaviour
{
    [SerializeField] private Vector3 cameraHeadPosition;

    [SerializeField] private Transform restingPosition;

    [Tooltip("Keep as negative number")]
    [SerializeField] private float maxRightRotationAngle; // should be a negative number (Allows custom inputs to rotation angle)

    [Tooltip("Keep as positive number")]
    [SerializeField] private float maxLeftRotationAngle; // should be a positive number (Allows custom inputs to rotation angle)

    [SerializeField] private float cameraSpeed;

    [SerializeField] private float angleFromRestingPosition;

    [SerializeField] private bool maxRightRotation = false;


    private void Update()
    {
        CameraRotation();
    }
    private void CameraRotation() // camera will automatically move right to left (Scanning) using angles and vector math
    {

        Vector3 directionToRestingPosition = restingPosition.position - transform.position;

        angleFromRestingPosition = Vector3.SignedAngle(transform.forward, directionToRestingPosition, Vector3.up);

        if (maxRightRotation == false)
        {
            cameraHeadPosition = new Vector3(0, 20, 0);

            transform.Rotate(cameraHeadPosition * cameraSpeed * Time.deltaTime);

            if (angleFromRestingPosition < maxRightRotationAngle)
            {
                maxRightRotation = true;
            }
        }
        if (maxRightRotation == true)
        {
            cameraHeadPosition = new Vector3(0, -20, 0);

            transform.Rotate(cameraHeadPosition * cameraSpeed * Time.deltaTime);

            if (angleFromRestingPosition > maxLeftRotationAngle)
            {
                maxRightRotation = false;
            }
        }


    }
}
