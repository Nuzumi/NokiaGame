using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private NativeEvent EnemyDiedEvent;

    private Damageable damageable;
    private float lastShootTime;
    private Shooter shooter;
    private GameObject player;
    private new Rigidbody rigidbody;
    private float moveTimeLeft;
    private Vector3 moveVector;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        damageable = GetComponent<Damageable>();
        damageable.startingHealthPoint = enemyData.healthPoint;
        damageable.ActualHealthPoint = enemyData.healthPoint;
        lastShootTime = enemyData.fireRate;
        shooter = transform.GetComponentInChildren<Shooter>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        if(Time.timeSinceLevelLoad > lastShootTime + enemyData.fireRate)
        {
            lastShootTime = Time.timeSinceLevelLoad;
            shooter.Shoot();
        }
    }

    private void FixedUpdate()
    {
        moveTimeLeft -= Time.deltaTime;
        if (moveTimeLeft < 0)
            MakeRandomMove();

        rigidbody.AddForce(moveVector * enemyData.enemySpeed);
    }

    private void MakeRandomMove()
    {
        moveTimeLeft = Random.Range(enemyData.minMoveTime, enemyData.maxMoveTime);
        moveVector = new Vector3(Random.value, 0, Random.value);
    }

    private void Die()
    {
        EnemyDiedEvent.Invoke();
        gameObject.SetActive(false);
    }



}
