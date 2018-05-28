using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName ="BulletData", menuName = "ScriptableObjects/BulletData")]
    class BulletData : ScriptableObject
    {
        [SerializeField]
        private float speedModifier;
        public float SpeedModifier
        {
            get
            {
                return speedModifier;
            }
        }

        [SerializeField]
        private int damage;
        public int Damage
        {
            get
            {
                return damage;
            }
        }

    }
}
