using Character.Controllers;
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
            killInfo.Owner.GetComponent<MoneyController>().AddMoney(moneyAmount);
        }
    }
}
