using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is to define detectable objects 
/// </summary>
[CreateAssetMenu(fileName = "new detectable", menuName = "create new detectable", order = 0)]
public class DetectableObjects : ScriptableObject
{
    public string Name; // name of object

    public bool throwable; // is the object throwable

    public bool noiseMaker; // can the object make noise

    public bool cameraDetection; // can the object be seen by the camera 

}
