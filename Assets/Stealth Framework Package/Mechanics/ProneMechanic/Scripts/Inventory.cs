using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects //evidence of using namespaces
{
    /// <summary>
    /// this script creates a list for all scriptable object enemies
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        //creates list for scriptable objects
        public List <GameObject> enemyList = new List<GameObject>();
    }
}
