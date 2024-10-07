using System;
using UnityEngine;
using UnityEngine.Splines;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Behaviours
{
    public class EnemyBehaviour : CharacterSystemBase
    {
        private SplineContainer splineContainer;
        private DynamicStatisticsController dynamicStatisticsController;
        private DynamicStatisticValue speed;
        private float delta=0;
        private bool reachedStart = false;
        
        private void Awake()
        {
            dynamicStatisticsController = GetCharacterSystem<DynamicStatisticsController>();
            speed = dynamicStatisticsController.GetStatistic("Speed");
        }

        private void OnEnable()
        {
            reachedStart=false;
        }

        private void Update()
        {
            if (reachedStart)
            {
                var lenght = splineContainer.CalculateLength(0);
                var deltaSpeed = speed.Value / lenght;

                delta = Math.Clamp(delta + deltaSpeed * Time.deltaTime, 0, 1);
            }
            Move();
        }

        public void SetSpline(SplineContainer splineContainer)
        {
            this.splineContainer = splineContainer;
        }
        
        private void Move()
        {
            if (splineContainer == null)
                return;
            
            var point = splineContainer.EvaluatePosition(delta);
            transform.position = Vector3.MoveTowards(transform.position, point, speed.Value);
        }
    }
}
