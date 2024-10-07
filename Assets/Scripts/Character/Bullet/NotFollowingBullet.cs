using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class NotFollowingBullet : Pool.Objects.Bullet
    {
        private Vector3 target;

        public override void SetTarget(Collider2D target, float damage, LayerMask enemyLayer)
        {
            base.SetTarget(target, damage, enemyLayer);
            this.target = target.ClosestPoint(transform.position);
        }

        protected override Vector3 GetTargetPosition()
        {
            return target;
        }
    }
}
