using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Stealth.Framework.Motion.Camera
{

    /// <summary>
    /// This is a sub class varient to the original MotionCameraSystem
    /// </summary>
    public class FlashMotionCamera : MotionCameraSystem
    {
        [Header("Flash Light")]
        [SerializeField] private Light cameraFlash;

        void Update()
        {
            if (cameraDead != true)
            {
                CameraRotation(); // enables camera rotation 

                CameraSight(); // enables camera sight (detection)

                CameraFlash(); // enables flashing light when looking at player
            }

            ExplodeObject();
        }

        private void CameraFlash()
        {
            if (detectedTrigger == true)
            {
                cameraFlash.enabled = true;
            }
            if (detectedTrigger == false) 
            {
                cameraFlash.enabled = false;
            }
        }
    }
}
