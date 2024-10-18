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
        

        [Inject] private PanelManager panelManager;

        private int curretnLevel;
        private int currentExp;
        
        private HealthSystemBaseController healthSystemBaseController;
        
        public void AddExp(int exp)
        {
            currentExp += exp;
            if (LEVELS.Count <= curretnLevel)
                return;
            
            if (currentExp >= LEVELS[curretnLevel])
            {
                curretnLevel++;
                currentExp = 0;
                panelManager.OpenPanel("LevelUpPanelTurret", new PanelDataBase() {Data = this});
            }
        }
    }
}
