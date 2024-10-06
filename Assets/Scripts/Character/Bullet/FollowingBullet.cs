using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class FollowingBullet : Pool.Objects.Bullet
    {
        private Transform target;
        private Vector3 lastTargetPosition;

        private void Update()
        {
            if (target != null)
                lastTargetPosition = target.position;
        }
        
        public override void SetTarget(object target, float damage)
        {
            this.target = (Transform) target;
            this.damage = damage;
        }

        protected override Vector3 GetTargetPosition()
        {
            if(target != null)
                return target.position;
            return lastTargetPosition;
        }
    }
}
