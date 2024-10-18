using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Character.Controllers
{
    public class ExpController : MonoBehaviour
    {
        private readonly List<int> LEVELS = new List<int> { 50, 100, 200, 300 };
        
        public int CurretnLevel => curretnLevel;
        public int CurretnExp => currentExp;
        
        [SerializeField] private int expAfterDead = 10;
        [SerializeField] private bool isPlayer;

        [Inject] private PanelManager panelManager;

        private int curretnLevel;
        private int currentExp;
        
        private HealthSystemBaseController healthSystemBaseController;
        
        void Awake()
        {
            healthSystemBaseController = GetComponent<HealthSystemBaseController>();
            healthSystemBaseController.OnKilled.AddListener(GiveExp);
        }

        private void GiveExp(KillInfo arg0)
        {
            
        }

        private void AddExp(int exp)
        {
            currentExp += exp;
            if (currentExp >= LEVELS[curretnLevel])
            {
                curretnLevel++;
                currentExp = 0;
                panelManager.OpenPanel("LevelUpPanel", new PanelDataBase() {Data = this});
            }
        }
    }
}
