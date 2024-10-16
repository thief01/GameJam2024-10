using System;
using System.Collections.Generic;
using Character.Behaviours;
using Pool.Objects;
using UnityEngine;
using UnityEngine.Splines;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Spawners
{
    public class TDEnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 1;
        [SerializeField] private List<int> spawnEnemies;
        [SerializeField] private int spawnCount = 1;
        
        [Inject] private PoolBase<Enemy> enemyPool;
        
        private int currentSpawnCount = 0;
        
        private void Update()
        {
            spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0)
            {
                spawnDelay = 1;
                SpawnUnit(spawnEnemies[UnityEngine.Random.Range(0, spawnEnemies.Count)]);
            }
        }
        
        private void SpawnUnit(int id)
        {
            if (spawnCount != 0 && currentSpawnCount >= spawnCount)
            {
                return;
            }
            var spawnedEnemy = enemyPool.SpawnObject(id);
            spawnedEnemy.transform.position = transform.position;
            // var enemyBehaviour = spawnedEnemy.GetComponent<EnemyBehaviour>();
        }
    }
}