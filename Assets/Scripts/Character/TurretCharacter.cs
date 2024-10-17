using System;
using Character.Behaviours;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;

namespace Character
{
    public class TurretCharacter : CharacterBase
    {
        public TurretBehaviour TurretBehaviour { get; private set; }
        public DynamicStatisticsController DynamicStatisticsController { get; private set; }

        private void Awake()
        {
            TurretBehaviour = GetComponent<TurretBehaviour>();
            DynamicStatisticsController = GetComponent<DynamicStatisticsController>();
        }

        public override void Move(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }

        public override void UseSkill(int skillIndex)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateMousePosition(Vector2 mousePosition)
        {
            throw new System.NotImplementedException();
        }
        
        public void Upgrade()
        {
            
        }
    }
}
