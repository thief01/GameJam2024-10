using System;
using Character.TrainSlots;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controlers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;

namespace Character.Info
{
    public class TurretAttackRange : MonoBehaviour
    {
        [SerializeField] private Transform turretAttackRange;
        private TrainSlot trainSlot;

        private TurretCharacter turretCharacter;
        private DynamicStatisticValue attackRange;

        private void Awake()
        {
            trainSlot = GetComponentInParent<TrainSlot>();
        }


        private void Update()
        {
            if (trainSlot.TurretAttached == null)
            {
                turretAttackRange.gameObject.SetActive(false);
                return;
            }
            
            turretAttackRange.gameObject.SetActive(trainSlot.IsSelected);
            
            if (turretCharacter == null || turretCharacter != trainSlot.TurretAttached)
            {
                InitTurret();
            }
            
            UpdateAttackRange();
        }

        private void InitTurret()
        {
            turretCharacter = trainSlot.TurretAttached;
            attackRange = turretCharacter.DynamicStatisticsController.GetStatistic("AttackRange");
        }
        
        private void UpdateAttackRange()
        {
            turretAttackRange.localScale = new Vector3(attackRange.Value * 4, attackRange.Value * 4, 1);
        }
    }
}
