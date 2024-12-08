using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stealth.Framework.Motion.Camera
{
    /// <summary>
    /// delegate event host script
    /// </summary>
    public static class DetectionEvent
    {
        public delegate void CustomCameraEvent();

        public static CustomCameraEvent OnDetectionEvent;
    }
}
