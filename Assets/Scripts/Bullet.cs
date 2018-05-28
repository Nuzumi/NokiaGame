using Assets.Scripts.Events;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Bullet : MonoBehaviour
    {
        public BulletData bulletData;

        [SerializeField]
        private BulletEvent bulletEvent;


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("GameArea"))
            {
                bulletEvent.Invoke(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageable = collision.gameObject.GetComponent<Damageable>();
            if(damageable != null)
            {
                damageable.GetDamage(bulletData.Damage);
            }
            bulletEvent.Invoke(gameObject);
        }

    }
}
