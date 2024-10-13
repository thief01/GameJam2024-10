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
        
        public override void SetTarget(float damage, TargetInfo targetInfo)
        {
            if (targetInfo.IsTargetNull())
            {
                Kill();
                return;
            }
            base.SetTarget(damage, targetInfo);
            lastTargetPosition = targetInfo.GetTargetPosition(transform.position);
        }

        protected override Vector3 GetTargetPosition()
        {
            if (!targetInfo.IsTargetNull())
            {
                lastTargetPosition = targetInfo.GetTargetPosition(transform.position);
                return lastTargetPosition;
            }

            return lastTargetPosition;
        }
    }
}
