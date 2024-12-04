using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
/// <summary>
/// this script defines the variables of scriptable objects (enemy types)
/// </summary>
namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Create New Enemy", order = 0)]

    public class EnemyIndex : ScriptableObject //evidence of using scriptable object
    {
        public string enemyName;
        public int enemyID;
        public int enemyHealth;
        public int enemyLevel;
        public int enemyDamage;
    }
}
