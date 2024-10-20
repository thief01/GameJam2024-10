using System;
using System.Collections.Generic;
using Character.Behaviours;
using Character.General;
using Pool.Objects;
using UnityEngine;
using UnityEngine.Splines;
using WRA_SDK.WRA.General;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Spawners
{
    public class TDEnemySpawner : MonoBehaviour
    {
        public int LeftEnemies => spawnedEnemies.Count + spawnCount;
        [SerializeField] private float spawnDelay = 1;
        [SerializeField] private List<int> spawnEnemies;
        [SerializeField] private int spawnCount = 1;

        
        [Inject] private PoolBase<Enemy> enemyPool;
        private GameManager gameManager;
        private List<Enemy> spawnedEnemies = new List<Enemy>();
        
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
            if (spawnCount != -1 && currentSpawnCount >= spawnCount)
            {
                return;
            }
            var spawnedEnemy = enemyPool.SpawnObject(id);
            spawnedEnemy.transform.position = transform.position;
            var enemy = spawnedEnemy as Enemy;
            spawnedEnemies.Add(enemy);
            enemy.HealthSystemBaseController.OnKilled.AddListener(OnKill);
            currentSpawnCount++;
        }

        private void OnKill(KillInfo killInfo)
        {
            var killed = spawnedEnemies.Find(ctg => ctg.HealthSystemBaseController == killInfo.KilledUnit);
            if (killed != null)
            {
                spawnedEnemies.Remove(killed);
                killed.HealthSystemBaseController.OnKilled.RemoveListener(OnKill);
            }
        }
    }
}