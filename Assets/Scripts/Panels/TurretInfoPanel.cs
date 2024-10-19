using Character.Controllers;
using Character.TrainSlots;
using Pool.Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class TurretInfoPanel : InfoPanelBase
    {
        [SerializeField] private TextMeshProUGUI availableUpgrades;
        [SerializeField] private Button upgradeButton;

        private ExpController expController;
        private Train train;
        private TrainSlot trainSlot;

        public void Sell()
        {
            trainSlot.SellTurret();
        }

        public void Upgrade()
        {
            if (expController.AvailableUpgradePoints <= 0)
                return;
            ParentPanel.PanelManager.OpenPanel("LevelUpPanelTurret", new PanelDataBase() { Data = trainSlot });
        }
        
        protected override void UpdatePanelData()
        {
            trainSlot = (TrainSlot)ParentPanel.GetDataAsType<PanelDataBase>().Data;
            title.text = trainSlot.name + " - " + trainSlot.TurretAttached.name;
            train = trainSlot.Train;
            expController = train.ExpController;
            expController.OnValueChanged.AddListener(OnExpChanged);
            OnExpChanged();
        }

        private void OnExpChanged()
        {
            upgradeButton.interactable = expController.AvailableUpgradePoints > 0;
            availableUpgrades.text = "Available upgrades: " + expController.AvailableUpgradePoints;
        }
    }
}
