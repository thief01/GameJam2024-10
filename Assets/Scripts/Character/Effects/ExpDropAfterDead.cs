using Character.Controllers;
using Pool.Spawners;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character.Effects
{
    public class ExpDropAfterDead : MonoBehaviour
    {
        [SerializeField] private int expCount;
        
        private HealthSystemBaseController healthSystemBaseController;
        
        void Awake()
        {
            healthSystemBaseController = GetComponent<HealthSystemBaseController>();
            healthSystemBaseController.OnKilled.AddListener(DropMoney);
        }
        
        void DropMoney(KillInfo killInfo)
        {
            TrainSpawner.Train.ExpController.AddExp(expCount);
        }
    }
}
