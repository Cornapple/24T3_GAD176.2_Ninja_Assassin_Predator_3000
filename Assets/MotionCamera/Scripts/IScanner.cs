using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This class gives instructions on scannable objects
/// </summary>
namespace Stealth.Framework.Motion.Camera
{
    public interface IScanner
    {
        void CameraRotation();

        void CameraSight();

    }
}


