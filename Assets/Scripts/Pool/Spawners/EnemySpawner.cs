using System;
using System.Collections.Generic;
using Pool.Objects;
using UnityEngine;
using UnityEngine.Splines;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [System.Serializable]
        private struct Wave
        {
            public int enemyId;
            public int count;
            public float delay;
            public SplineContainer splineContainer;
        }
        
        [SerializeField] private float timeBetweenWaves = 5f;
        [SerializeField] private float timeBetweenEnemies = 1f;
        
        [SerializeField] private List<Wave> waves = new List<Wave>();
        
        [Inject] private PoolBase<Enemy> enemyPool;
        
        private int enemiesToSpawn;
        private int currentWave = -1;
        private float timeToNextEnemy;
        private float timeToNextWave;

        private void Update()
        {
            if(currentWave>=waves.Count)
                return;
            
            WaveCheck();
            UnitCheck();
        }

        private void WaveCheck()
        {
            if (enemiesToSpawn > 0)
            {
                timeToNextWave = timeBetweenWaves;
                return;
            }

            timeToNextWave -= Time.deltaTime;
            
            if(timeToNextWave > 0)
                return;
            
            currentWave++;
            
            if (currentWave >= waves.Count)
                return;

            enemiesToSpawn = waves[currentWave].count;
            timeToNextEnemy = waves[currentWave].delay;
        }
        
        private void UnitCheck()
        {
            if (enemiesToSpawn <= 0)
                return;

            timeToNextEnemy -= Time.deltaTime;
            
            if (timeToNextEnemy > 0)
                return;

            enemiesToSpawn--;
            timeToNextEnemy = timeBetweenEnemies;
            SpawnUnit();
        }
        
        private void SpawnUnit()
        {
            var wave = waves[currentWave];
            var enemy = wave.enemyId;
            var spline = wave.splineContainer;
            
            // Spawn enemy
            var spawnedEnemy = enemyPool.SpawnObject(enemy);
            spawnedEnemy.transform.position = transform.position;

        }
    }
}
