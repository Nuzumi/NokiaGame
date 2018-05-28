using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private Vector3 maxPoint;

    [SerializeField]
    private Vector3 minPoint;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private NativeEvent EnemyDiedEvent;

    [SerializeField]
    private NativeEvent EndGameEvent;
        
    private int enemiesCount;
    private int actualEnemyCount;

    private void OnEnable()
    {

        EnemyDiedEvent.AddListener(EnemyDied);
    }

    private void OnDisable()
    {
        EnemyDiedEvent.RemoveListener(EnemyDied);
    }

    private void Start()
    {
        enemiesCount = FindObjectOfType<DataStorage>().EnemyCount;
        actualEnemyCount = enemiesCount;
        CreateEnemies();
    }

    private void CreateEnemies()
    {
        for(int i = 0; i < enemiesCount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minPoint.x, maxPoint.x), Random.Range(minPoint.y, maxPoint.y), Random.Range(minPoint.z, maxPoint.z));
    }

    private void EnemyDied()
    {
        actualEnemyCount--;
        if(actualEnemyCount == 0)
        {
            EndGameEvent.Invoke();
        }
    }
}
