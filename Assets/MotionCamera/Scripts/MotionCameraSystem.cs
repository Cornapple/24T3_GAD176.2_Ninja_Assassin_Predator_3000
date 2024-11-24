using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This class defines specific characteristics about the camera 
/// <summary>
namespace Stealth.Framework.Motion.Camera
{
    public class MotionCameraSystem : MonoBehaviour, IScanner
    {
        #region CameraVariables

        [SerializeField] private Vector3 cameraHeadPosition; // used to rotate the camera

        [SerializeField] private Transform restingPosition; // used to detect SignedAngle 

        [Tooltip("Keep as negative number")]
        [SerializeField] private float maxRightRotationAngle; // should be a negative number (Allows custom inputs to rotation angle)

        [Tooltip("Keep as positive number")]
        [SerializeField] private float maxLeftRotationAngle; // should be a positive number (Allows custom inputs to rotation angle)

        [SerializeField] private float cameraSpeed; // can change speed of rotating camera

        [SerializeField] private float angleFromRestingPosition; // gets the angle from the original resting position to where the camera currently is

        [SerializeField] private bool maxRightRotation = false; // detects max rotation angles

        [SerializeField] private float raycastDistance; // controls length of raycast (Camera Sight)

        [SerializeField] private LayerMask raycastPhysicsLayers; // controls what the camera can detect (via layers)


        #endregion

        private void OnEnable() // subscribes to an event
        {
            DetectionEvent.OnDetectionEvent += CameraTriggerEvent;
        }

        private void OnDisable() // un-subscribes to an event
        {
            DetectionEvent.OnDetectionEvent -= CameraTriggerEvent;
        }

        private void Start()
        {
            transform.LookAt(restingPosition); // allows moving of camera resting position - enabling easy custom camera angles from start position
        }

        public void Update()
        {
            CameraRotation();

            CameraSight();

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

        private void CameraSight() // cameras vision detection area
        {
            RaycastHit cameraFound;

            Debug.DrawRay(transform.position, transform.forward);

            if (Physics.Raycast(transform.position, transform.forward, out cameraFound, raycastDistance, raycastPhysicsLayers))
            {
                Debug.Log("Camera Detected: " + cameraFound.transform.name);

                if (cameraFound.transform.GetComponent<CameraTrigger>())
                {
                    Debug.Log("The cameras trigger has been found");

                    DetectionEvent.OnDetectionEvent?.Invoke(); // calling custom event once trigger has been found
                }
            }

        }

        private void CameraTriggerEvent() // define custom event logic here
        {
            Debug.Log("Custom Camera Event has been Triggered");
        }

       
    }
}
