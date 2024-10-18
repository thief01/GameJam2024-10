using Character.Controllers;
using Pool.Spawners;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character.Effects
{
    public class MoneyDropAfterDead : MonoBehaviour
    {
        [SerializeField] private int moneyAmount = 10;
        private HealthSystemBaseController healthSystemBaseController;
        
        void Awake()
        {
            healthSystemBaseController = GetComponent<HealthSystemBaseController>();
            healthSystemBaseController.OnKilled.AddListener(DropMoney);
        }
        
        void DropMoney(KillInfo killInfo)
        {
            TrainSpawner.Train.MoneyController.AddMoney(moneyAmount);
        }
    }
}
