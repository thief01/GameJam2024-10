using System;
using Character.Behaviours;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Objects
{
    public class Enemy : CharacterObject
    {
        public Transform Train => train;
        
        [Inject] private Transform train;
        
        private HealthSystemBaseController healthSystemBaseController;
        private EnemyBehaviour enemyBehaviour;
        
        private void Awake()
        {
            
            healthSystemBaseController = GetComponent<HealthSystemBaseController>();
            enemyBehaviour = GetComponent<EnemyBehaviour>();
            healthSystemBaseController.OnKilled.AddListener(ctg => Kill());
        }

        public override void OnInit()
        {
            
        }

        public override void OnSpawn()
        {
            gameObject.SetActive(true);
            healthSystemBaseController.Heal(new HealInfo() {CalculatedValueChanged = healthSystemBaseController.MaxValueStatistic.Value});
        }

        public override void OnBeginKill(float delay)
        {
            
        }

        public override void OnKill()
        {
            
        }
    }
}