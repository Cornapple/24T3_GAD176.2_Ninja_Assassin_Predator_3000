using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This class defines specific characteristics about the camera 
/// <summary>
namespace Stealth.Framework.Motion.Camera
{
    public class MotionCameraSystem : MonoBehaviour, IScanner, IDamageable
    {
        #region CameraVariables

        [Header("Statistics")]
        [SerializeField] protected Vector3 cameraHeadPosition; // used to rotate the camera

        [SerializeField] protected Transform restingPosition; // used to detect SignedAngle 

        [Header("Rotation")]
        [Tooltip("Keep as negative number")]
        [SerializeField] protected float maxRightRotationAngle; // should be a negative number (Allows custom inputs to rotation angle)

        [Tooltip("Keep as positive number")]
        [SerializeField] protected float maxLeftRotationAngle; // should be a positive number (Allows custom inputs to rotation angle)

        [SerializeField] protected float cameraSpeed; // can change speed of rotating camera

        [SerializeField] protected float angleFromRestingPosition; // gets the angle from the original resting position to where the camera currently is

        [SerializeField] protected bool maxRightRotation = false; // detects max rotation angles

        [Header("Detection")]
        [SerializeField] protected bool detectedTrigger = false; // used for inherited scripts to determine when the trigger has been spotted

        [SerializeField] protected float raycastDistance; // controls length of raycast (Camera Sight)

        [SerializeField] protected LayerMask raycastPhysicsLayers; // controls what the camera can detect (via layers)


        #endregion

        #region ExplodeVariables

        [Header("Camera Explode")]
        [Tooltip("Setting this to true will destroy the camera")]
        [SerializeField] protected bool cameraDead = false;
        [SerializeField] protected Rigidbody Neck;
        [SerializeField] protected Rigidbody Head;
        [SerializeField] protected Rigidbody Pivot;

        #endregion

        #region SpottedUI

        public SpottedUI UI_Spotted;

        #endregion

        #region CustomEvent
        protected void OnEnable() // subscribes to an event
        {
            DetectionEvent.OnDetectionEvent += CameraTriggerEvent;
        }

        protected void OnDisable() // un-subscribes to an event
        {
            DetectionEvent.OnDetectionEvent -= CameraTriggerEvent;
        }

        protected void CameraTriggerEvent() // define custom event logic here
        {
            Debug.Log("Custom Camera Event has been Triggered");
        }

        #endregion

        protected void Start()
        {
            transform.LookAt(restingPosition); // allows moving of camera resting position - enabling easy custom camera angles from start position

            if (UI_Spotted == null)
            {
                UI_Spotted = FindObjectOfType<SpottedUI>();
            }
        }

        void Update()
        {

            if (cameraDead != true)
            {
                CameraRotation(); // enables camera rotation 

                CameraSight(); // enables camera sight (detection)
            }

            ExplodeObject(); // if camera is dead, explode
        }

        public void CameraRotation() // camera rotation logic
        {
            Vector3 directionToRestingPosition = restingPosition.position - transform.position;

            angleFromRestingPosition = Vector3.SignedAngle(transform.forward, directionToRestingPosition, Vector3.up);

            if (maxRightRotation == false) // if one max rotation is true go to other max rotation
            {
                cameraHeadPosition = new Vector3(0, 20, 0);

                transform.Rotate(cameraHeadPosition * cameraSpeed * Time.deltaTime);

                if (angleFromRestingPosition < maxRightRotationAngle)
                {
                    maxRightRotation = true;
                }
            }
            if (maxRightRotation == true) // if one max rotation is true go to other max rotation
            {
                cameraHeadPosition = new Vector3(0, -20, 0);

                transform.Rotate(cameraHeadPosition * cameraSpeed * Time.deltaTime);

                if (angleFromRestingPosition > maxLeftRotationAngle)
                {
                    maxRightRotation = false;
                }
            }
        }

        public void CameraSight() // uses raycasting to detect the player and objects (camera vision/detection)
        {
            RaycastHit cameraFound;

            Debug.DrawRay(transform.position, transform.forward);

            if (Physics.Raycast(transform.position, transform.forward, out cameraFound, raycastDistance, raycastPhysicsLayers))
            {
                Debug.Log("Camera Detected: " + cameraFound.transform.name);

                if (cameraFound.transform.GetComponent<CameraTrigger>())
                {
                    Debug.Log("The cameras trigger has been found");

                    detectedTrigger = true;

                    UI_Spotted.triggerSpotted = true; // this bool allows the spotted UI to change to "SPOTTED"

                    Debug.Log("UI should change");

                    DetectionEvent.OnDetectionEvent?.Invoke(); // calling custom event once trigger has been found
                }
                if (!cameraFound.transform.GetComponent<CameraTrigger>())
                {

                    UI_Spotted.triggerSpotted = false;

                    detectedTrigger = false;

                }

            }
        }

        public void ExplodeObject()
        {
            if (cameraDead == true)
            {
                Neck.isKinematic = false;
                Head.isKinematic = false;
                Pivot.isKinematic = false;

                Vector3 explosionPosition = transform.position;
                Neck.AddExplosionForce(1.5f, explosionPosition, 3, 1, ForceMode.Force);
                Head.AddExplosionForce(1.5f, explosionPosition, 3, 1, ForceMode.Force);
                Pivot.AddExplosionForce(1.5f, explosionPosition, 3, 1, ForceMode.Force);

                Destroy(Neck.gameObject, 3);
                Destroy(gameObject, 3);
                
            }
        }
    }
}
