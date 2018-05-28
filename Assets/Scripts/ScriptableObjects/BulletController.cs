using Assets.Scripts;
using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BulletController", menuName = "ScriptableObjects/BulletController")]
public class BulletController : ScriptableObject {

    [SerializeField]
    private BulletEvent bulletEvent;

    [SerializeField]
    private GameObject bullet;

    private Queue<GameObject> bulletsToUse = new Queue<GameObject>();

    private void OnEnable()
    {
        bulletEvent.AddListener(AddBullet);
    }

    private void OnDisable()
    {
        bulletEvent.RemoveListener(AddBullet);
    }

    public GameObject GetBullet()
    {
        if(bulletsToUse.Count != 0)
        {
            return bulletsToUse.Dequeue();
        }
        else
        {
            return Instantiate(bullet);
        }
    }

    private void AddBullet(GameObject bulletToAdd)
    {
        bulletToAdd.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bulletToAdd.SetActive(false);
        bulletsToUse.Enqueue(bulletToAdd);
    }
}
