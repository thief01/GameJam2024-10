using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class NotFollowingBullet : Pool.Objects.Bullet
    {
        private Vector3 target;


        public override void SetTarget(object target, float damage)
        {
            this.target = (Vector3) target;
            this.damage = damage;
        }

        protected override Vector3 GetTargetPosition()
        {
            return target;
        }
    }
}
