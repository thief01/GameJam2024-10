using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Character.Controllers
{
    public class ExpController : CharacterSystemBase
    {
        private const int BASE_MAX_EXP = 50;
        private const int LEVEL_UPGRADE_EXP = 50;
        private const int LEVEL_5_UPGRADE_EXP = 200;
        
        public UnityEvent OnValueChanged;
        
        public int AvailableUpgradePoints { get; private set; } = 0;
        
        public int CurretnLevel => curretnLevel;
        public int CurretnExp => currentExp;

        public int CurrentMaxExp { get; private set; } = BASE_MAX_EXP;
        

        [Inject] private PanelManager panelManager;

        private int curretnLevel;
        private int currentExp;
        
        private HealthSystemBaseController healthSystemBaseController;
        
        public void AddExp(int exp)
        {
            currentExp += exp;
            OnValueChanged.Invoke();
            if (CurrentMaxExp <= curretnLevel)
                return;
            
            if (currentExp >= CurrentMaxExp)
            {
                curretnLevel++;
                currentExp = CurretnExp - CurrentMaxExp;
                AvailableUpgradePoints++;
                RecalculateMaxExp();
            }
        }
        
        private void RecalculateMaxExp()
        {
            var fiveLevels = curretnLevel / 5;
            CurrentMaxExp = BASE_MAX_EXP + LEVEL_UPGRADE_EXP * curretnLevel + LEVEL_5_UPGRADE_EXP * fiveLevels;
        }
    }
}
