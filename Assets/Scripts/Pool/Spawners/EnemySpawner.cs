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
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 1;
        [SerializeField] private List<int> spawnEnemies;
        
        [Inject] private PoolBase<Enemy> enemyPool;
        
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
            var spawnedEnemy = enemyPool.SpawnObject(id);
            spawnedEnemy.transform.position = transform.position;
            // var enemyBehaviour = spawnedEnemy.GetComponent<EnemyBehaviour>();
        }
    }
}