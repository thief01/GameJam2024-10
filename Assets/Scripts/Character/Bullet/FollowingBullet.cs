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
        
        public override void SetTarget(Transform target, float damage)
        {
            this.target = target;
            this.damage = damage;
        }

        protected override Vector3 GetTargetPosition()
        {
            if (target != null)
            {
                lastTargetPosition = target.position;
                return target.position;
            }

            return lastTargetPosition;
        }
    }
}
