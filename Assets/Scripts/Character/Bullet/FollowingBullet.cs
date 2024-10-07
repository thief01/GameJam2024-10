using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class FollowingBullet : Pool.Objects.Bullet
    {
        private Vector3 lastTargetPosition;
        
        public override void SetTarget(Transform target, float damage, LayerMask enemyLayer)
        {
            base.SetTarget(target, damage, base.enemyLayer);
            lastTargetPosition = target.position;
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
