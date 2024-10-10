using System;
using Character.Behaviours;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.General.Patterns.Pool;

namespace Pool.Objects
{
    public class Enemy : PoolObjectBase
    {
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
            enemyBehaviour.OnSpawn();
        }

        public override void OnBeginKill(float delay)
        {
            
        }

        public override void OnKill()
        {
            
        }
    }
}