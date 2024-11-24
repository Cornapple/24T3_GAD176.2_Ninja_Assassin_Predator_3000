using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stealth.Framework.Motion.Camera
{
    public static class DetectionEvent
    {
        public delegate void CustomCameraEvent();

        public static CustomCameraEvent OnDetectionEvent;
    }
}
