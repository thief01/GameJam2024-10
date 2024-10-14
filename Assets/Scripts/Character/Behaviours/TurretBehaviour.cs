using System;
using Character.Bullet;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Character.Behaviours
{
    public class TurretBehaviour : CharacterSystemBase
    {
        public UnityEvent OnShoot;
        public float AttackCooldownPercentage => attackCooldown / (1 / attackSpeed.Value);
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private int bulletId;
        [SerializeField] private Transform muzzle;
        
        [Inject] private PoolBase<Pool.Objects.Bullet> bulletPool;
        
        private DynamicStatisticsController dynamicStatisticsController;
        private DynamicStatisticValue attackRange;
        private DynamicStatisticValue rotationSpeed;
        private DynamicStatisticValue attackSpeed;
        
        private Collider2D[] enemiesInRange;
        private float attackCooldown;
        
        private bool rotatedTowardsEnemy;
        private Collider2D target;
        private Vector3 targetPosition;

        private GameControlls gameControlls;
        private bool isControlled;
        private bool isAttacking;


        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if(!isControlled)
                FindEnemies();
            RotateTowardsTarget();
            
            if (attackCooldown <= 0)
            {
                Attack();
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
        }
        
        private void Init()
        {
            dynamicStatisticsController = GetComponent<DynamicStatisticsController>();
            attackRange = dynamicStatisticsController.GetStatistic("AttackRange");
            rotationSpeed = dynamicStatisticsController.GetStatistic("RotationSpeed");
            attackSpeed = dynamicStatisticsController.GetStatistic("AttackSpeed");
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
        
        public void TakeControl(GameControlls controlls)
        {
            isControlled = true;
            gameControlls = controlls;
        }
        
        public void ReleaseControl()
        {
            isControlled = false;
            if(gameControlls == null)
                return;
            gameControlls = null;
        }

        private void FindEnemies()
        {
            enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange.Value, enemyLayer);
        }
        
        private void RotateTowardsTarget()
        {
            targetPosition = GetClosestTarget();

            if (!isControlled && target == null)
                return;

            var direction = (targetPosition - transform.position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed.Value * Time.deltaTime);
            var angleDifference = Quaternion.Angle(transform.rotation, rotation);
            rotatedTowardsEnemy = angleDifference < 1;
        }
        
        private void Attack()
        {
            if (!rotatedTowardsEnemy)
                return;
            if(!isControlled && target == null)
                return;
            
            var bullet = bulletPool.SpawnObject(bulletId) as Pool.Objects.Bullet;
            bullet.transform.position = muzzle.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.SetActive(true);
            attackCooldown = 1 / attackSpeed.Value;
            
            var targetInfo = new TargetInfo(isControlled) {Owner = this, Target = target, EnemyLayer = enemyLayer};
            targetInfo.SetDummyTarget(targetPosition);

            bullet.SetTarget( dynamicStatisticsController.GetStatistic("Damage").Value, targetInfo);
            OnShoot.Invoke();
        }
        
        private Vector3 GetClosestTarget()
        {
            target = null;
            if (isControlled)
            {
                return Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            
            Collider2D closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (var enemy in enemiesInRange)
            {
                var distance = Vector2.Distance(transform.position, enemy.transform.position);
                var healthSystemBaseController = enemy.GetComponent<HealthSystemBaseController>();
                if (distance < closestDistance && healthSystemBaseController.Alive)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy == null)
            {
                return Vector3.zero;
            }

            target = closestEnemy;
            return closestEnemy.ClosestPoint(transform.position);
        }
    }
}
