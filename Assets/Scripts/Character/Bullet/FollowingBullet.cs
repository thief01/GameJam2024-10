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

        public void SetTarget(Transform t, float damage)
        {
            target = t;
            lastTargetPosition = target.position;
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
