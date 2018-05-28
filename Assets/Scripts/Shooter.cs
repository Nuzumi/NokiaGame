using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Shooter : MonoBehaviour
    {
        [SerializeField]
        private NativeEvent OnShootEvent;

        [SerializeField]
        private BulletController bulletController;

        //Dev part
        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        Shoot();
        //    }
        //}


        public void Shoot()
        {
            if (OnShootEvent != null)
            {
                OnShootEvent.Invoke();
            }
               
            GameObject bullet = bulletController.GetBullet();
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
            var bulletClass = bullet.GetComponent<Bullet>();
            bulletClass.GetComponent<Rigidbody>().AddForce(transform.forward * bulletClass.bulletData.SpeedModifier);
        }
    }
}
