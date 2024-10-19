using Character.Controllers;
using Character.TrainSlots;
using Pool.Objects;
using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class TurretInfoPanel : InfoPanelBase
    {
        [SerializeField] private TextMeshProUGUI availableUpgrades;

        private ExpController expController;
        private Train train;
        private TrainSlot trainSlot;

        public void Sell()
        {
            trainSlot.SellTurret();
        }

        public void Upgrade()
        {
            ParentPanel.PanelManager.OpenPanel("LevelUpPanelTurret", new PanelDataBase() { Data = trainSlot });
        }
        
        protected override void UpdatePanelData()
        {
            trainSlot = (TrainSlot)ParentPanel.GetDataAsType<PanelDataBase>().Data;
            title.text = trainSlot.name + " - " + trainSlot.TurretAttached.name;
            train = trainSlot.Train;
            expController = train.ExpController;
            expController.OnValueChanged.AddListener(OnExpChanged);
        }

        private void OnExpChanged()
        {
            availableUpgrades.text = "Available upgrades: " + expController.AvailableUpgradePoints;
        }
    }
}
