using System;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Bullet
{
    public class NotFollowingBullet : Pool.Objects.Bullet
    {
        private Vector3 target;

        public override void SetTarget(float damage, TargetInfo targetInfo)
        {
            if (targetInfo.IsTargetNull())
            {
                Kill();
                return;
            }
            base.SetTarget(damage, targetInfo);
            target = targetInfo.GetTargetPosition(transform.position);
        }

        protected override Vector3 GetTargetPosition()
        {
            return target;
        }
    }
}
