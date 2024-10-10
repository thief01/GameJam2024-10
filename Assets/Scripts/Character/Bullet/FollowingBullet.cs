using System;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class FollowingBullet : Pool.Objects.Bullet
    {
        private Vector3 lastTargetPosition;
        
        public override void SetTarget(Collider2D target, float damage, LayerMask enemyLayer, CharacterSystemBase owner)
        {
            base.SetTarget(target, damage, base.enemyLayer, owner);
            lastTargetPosition = target.ClosestPoint(transform.position);
        }

        protected override Vector3 GetTargetPosition()
        {
            if (target != null)
            {
                lastTargetPosition = target.ClosestPoint(transform.position);
                return lastTargetPosition;
            }

            return lastTargetPosition;
        }
    }
}
