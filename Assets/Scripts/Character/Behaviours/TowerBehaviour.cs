using System;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Behaviours
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayer;
        private DynamicStatisticsController dynamicStatisticsController;
        private DynamicStatisticValue attackRange;
        private DynamicStatisticValue rotationSpeed;
        
        private Collider2D[] enemiesInRange;

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            FindEnemies();
            RotateTowardsEnemy();
        }
        
        private void Init()
        {
            dynamicStatisticsController = GetComponent<DynamicStatisticsController>();
            attackRange = dynamicStatisticsController.GetStatistic("AttackRange");
            rotationSpeed = dynamicStatisticsController.GetStatistic("RotationSpeed");
        }

        private void OnDrawGizmosSelected()
        {
            if (Application.isEditor)
            {
                Init();
            }
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange.Value);
        }

        private void FindEnemies()
        {
            enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange.Value, enemyLayer);
        }
        
        private void RotateTowardsEnemy()
        {
            var closestEnemy = GetClosestEnemy();
            if (closestEnemy == null)
            {
                return;
            }
            
            var direction = (closestEnemy.transform.position - transform.position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed.Value * Time.deltaTime);
        }
        
        private Collider2D GetClosestEnemy()
        {
            Collider2D closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (var enemy in enemiesInRange)
            {
                var distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}
