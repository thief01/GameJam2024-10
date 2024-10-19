using System;
using System.Collections.Generic;
using Character.Behaviours;
using Character.General;
using Pool.Objects;
using UnityEngine;
using UnityEngine.Splines;
using WRA_SDK.WRA.General;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Spawners
{
    public class TDEnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 1;
        [SerializeField] private List<int> spawnEnemies;
        [SerializeField] private int spawnCount = 1;

        private GameManager gameManager;
        [Inject] private PoolBase<Enemy> enemyPool;
        
        private bool isSpawning = false;
        private int currentSpawnCount = 0;

        private void Start()
        {
            gameManager.AddSpawner(this);
        }

        private void Update()
        {
            if (!isSpawning)
                return;
            
            spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0)
            {
                spawnDelay = 1;
                SpawnUnit(spawnEnemies[UnityEngine.Random.Range(0, spawnEnemies.Count)]);
            }
        }
        
        [Inject]
        public void ConstructGameManager(GameManagerBase gameManager)
        {
            this.gameManager = gameManager as GameManager;
        }

        public void StartSpawning()
        {
            isSpawning = true;
        }

        public void StopSpawning()
        {
            isSpawning = false;
        }
        
        private void SpawnUnit(int id)
        {
            if (spawnCount != 0 && currentSpawnCount >= spawnCount)
            {
                return;
            }
            var spawnedEnemy = enemyPool.SpawnObject(id);
            spawnedEnemy.transform.position = transform.position;
            spawnCount--;
            // var enemyBehaviour = spawnedEnemy.GetComponent<EnemyBehaviour>();
        }
    }
}