using System;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class NotFollowingBullet : Pool.Objects.Bullet
    {
        private Vector3 target;

        public override void SetTarget(Collider2D target, float damage, LayerMask enemyLayer, CharacterSystemBase owner)
        {
            if (target == null)
            {
                Kill();
                return;
            }
            base.SetTarget(target, damage, enemyLayer, owner);
            this.target = target.ClosestPoint(transform.position);
        }

        protected override Vector3 GetTargetPosition()
        {
            return target;
        }
    }
}
