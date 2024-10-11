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
            
        }


        private void SpawnUnit(int id)
        {
            
            // Spawn enemy
            var spawnedEnemy = enemyPool.SpawnObject(id);
            spawnedEnemy.transform.position = transform.position;
            var enemyBehaviour = spawnedEnemy.GetComponent<EnemyBehaviour>();
        }
    }
}