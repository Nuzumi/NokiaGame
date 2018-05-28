using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName ="EnemyData",menuName ="ScriptableObjects/EnemyData")]
    class EnemyData : ScriptableObject 
    {
        public int healthPoint;
        public float fireRate;
        public float enemySpeed;
        public float minMoveTime;
        public float maxMoveTime;
    }
}
