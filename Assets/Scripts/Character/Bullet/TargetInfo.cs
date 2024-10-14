using System.Diagnostics.Contracts;
using UnityEngine;
using WRA.CharacterSystems;

namespace Character.Bullet
{
    public class TargetInfo
    {
        public LayerMask EnemyLayer { get; set; }
        
        public CharacterSystemBase Owner { get; set; }

        public Collider2D Target { get; set; }
        private Vector3 TargetPosition { get; set; }
        
        private bool IsDummyTarget { get; set; }


        public TargetInfo(bool dummyTarget = false)
        {
            IsDummyTarget = dummyTarget;
        }
        
        public void SetDummyTarget(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
        
        public Vector3 GetTargetPosition(Vector3 from)
        {
            return IsTargetReallyNull() ? TargetPosition : Target.ClosestPoint(from);
        }

        public bool IsTargetNull()
        {
            if (IsDummyTarget)
            {
                return false;
            }
            return Target == null;
        }

        private bool IsTargetReallyNull()
        {
            return Target == null;
        }
    }
}
