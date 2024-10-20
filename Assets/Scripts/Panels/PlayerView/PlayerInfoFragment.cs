using System;
using Character.Controllers;
using Character.General;
using TMPro;
using UnityEngine;
using WRA_SDK.WRA.General;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Panels.PlayerView
{
    public class PlayerInfoFragment : PanelFragmentBase
    {
        [SerializeField] private CoolBar healthBar;
        [SerializeField] private CoolBar expBar;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI enemyCountText;

        private GameManager gameManager;
        private HealthSystemBaseController healthSystemBaseController;
        private ExpController expController;
        
        [Inject]
        public void ConstructGameManager(GameManagerBase gameManager)
        {
            this.gameManager = gameManager as GameManager;
        }

        public override void OnPanelDataChanged()
        {
            var player = ParentPanel.GetDataAsType<PanelDataBase>().Data as CharacterObject;
            healthSystemBaseController = player.GetCharacterSystem<HealthSystemBaseController>();
            healthSystemBaseController.OnValueChanged.AddListener(OnHealthChanged);
            expController = player.GetCharacterSystem<ExpController>();
            expController.OnValueChanged.AddListener(OnExpChanged);
            OnExpChanged();
            
            OnHealthChanged(1);
        }

        private void Update()
        {
            enemyCountText.text = $"Enemies: {gameManager.LeftEnemies}";
        }

        private void OnExpChanged()
        {
            expBar.SetValue(expController.CurretnExp, expController.CurrentMaxExp);
            levelText.text = $"Level {expController.CurretnLevel}";
        }

        private void OnHealthChanged(float value)
        {
            healthBar.SetValue(healthSystemBaseController.CurrentValue, healthSystemBaseController.MaxValueStatistic.Value);
        }
    }
}
