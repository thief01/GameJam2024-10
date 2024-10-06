using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Interfaces;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.CharacterSystems.StatisticsSystem.Statistics;
using WRA.General.Patterns.Pool;

namespace Pool.Objects
{
    public abstract class Bullet : PoolObjectBase
    {
        protected DynamicStatisticsController dynamicStatisticsController;
        protected DynamicStatisticValue speed;
        protected DynamicStatisticValue attackRange;
        protected float damage;
        
        private void Awake()
        {
            dynamicStatisticsController = GetComponent<DynamicStatisticsController>();
            speed = dynamicStatisticsController.GetStatistic("Speed");
            attackRange = dynamicStatisticsController.GetStatistic("AttackRange");
        }

        private void Update()
        {
            UpdatePosition();
            UpdateRotation();
            if (IsTargetInRange())
            {
                Kill();
            }
        }
        
        public override void OnInit()
        {
            
        }

        public override void OnSpawn()
        {
            
        }

        public override void OnBeginKill(float delay)
        {
            
        }

        public override void OnKill()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, attackRange.Value);
            foreach (var collider in colliders)
            {
                var enemy = collider.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    enemy.DealDamage(new DamageInfo() { DealtDamage = damage});
                }
            }
        }

        public void Spawn()
        {
            gameObject.SetActive(true);
        }

        public void Kill()
        {
            OnKill();
            gameObject.SetActive(false);
        }

        public void Kill(float delay)
        {
            
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Kill(KillInfo killInfo)
        {
           
        }
        
        private void UpdatePosition()
        {
            var targetPosition = GetTargetPosition();
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed.Value * Time.deltaTime);
        }
        
        private void UpdateRotation()
        {
            var direction = (GetTargetPosition() - transform.position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = rotation;
        }
        
        private bool IsTargetInRange()
        {
            return Vector3.Distance(transform.position, GetTargetPosition()) <= attackRange.Value;
        }
        
        
        public abstract void SetTarget(Transform target, float damage);
        protected abstract Vector3 GetTargetPosition();
    }
}
