using System;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.General.Patterns.Pool;

namespace Pool.Objects
{
    public class Enemy : PoolObjectBase
    {
        private HealthSystemBaseController healthSystemBaseController;

        private void Awake()
        {
            healthSystemBaseController = GetComponent<HealthSystemBaseController>();
            healthSystemBaseController.OnKilled.AddListener(ctg => Kill());
        }

        public override void OnInit()
        {
            
        }

        public override void OnSpawn()
        {
            gameObject.SetActive(true);
        }

        public override void OnBeginKill(float delay)
        {
            
        }

        public override void OnKill()
        {
            
        }
    }
}