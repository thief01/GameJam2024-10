using System;
using Pool.Objects;
using Pool.Spawners;
using UnityEngine;
using UnityEngine.Splines;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;
using Zenject;

namespace Character.Behaviours
{
    public class EnemyBehaviour : CharacterSystemBase
    {
        private DynamicStatisticsController dynamicStatisticsController;
        private DynamicStatisticValue speed;
        private DynamicStatisticValue attackRange;

        private Enemy enemy;
        
        private void Awake()
        {
            dynamicStatisticsController = GetCharacterSystem<DynamicStatisticsController>();
            speed = dynamicStatisticsController.GetStatistic("MovementSpeed");
            attackRange = dynamicStatisticsController.GetStatistic("AttackRange");
            enemy = GetComponent<Enemy>();
        }
        
        private void Update()
        {
            Move();
        }
        
        private void Move()
        {
            var point = TrainSpawner.Train.transform.position;
            if(Vector3.Distance(point, transform.position) > attackRange.Value - 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, point, speed.Value);
            }
        }
    }
}
