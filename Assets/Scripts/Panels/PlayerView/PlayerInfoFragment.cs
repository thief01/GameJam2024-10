using Character.Controllers;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.Statistics;
using WRA.UI.PanelsSystem;

namespace Panels.PlayerView
{
    public class PlayerInfoFragment : PanelFragmentBase
    {
        [SerializeField] private CoolBar healthBar;
        [SerializeField] private CoolBar expBar;

        private HealthSystemBaseController healthSystemBaseController;
        private ExpController expController;

        public override void OnPanelDataChanged()
        {
            var player = ParentPanel.GetDataAsType<PanelDataBase>().Data as CharacterObject;
            healthSystemBaseController = player.GetCharacterSystem<HealthSystemBaseController>();
            healthSystemBaseController.OnValueChanged.AddListener(OnHealthChanged);
            expController = player.GetCharacterSystem<ExpController>();
expController.OnValueChanged.AddListener(OnExpChanged);
            
            OnHealthChanged(1);
        }

        private void OnExpChanged()
        {
            expBar.SetValue(expController.CurretnExp, expController.CurrentMaxExp);
        }

        private void OnHealthChanged(float value)
        {
            healthBar.SetValue(healthSystemBaseController.CurrentValue, healthSystemBaseController.MaxValueStatistic.Value);
        }
    }
}
