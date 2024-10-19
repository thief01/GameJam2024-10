using Character.Behaviours;
using Character.Controllers;
using Character.TrainSlots;
using Pool.Objects;
using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class TurretLevelUpFragment : PanelFragmentBase
    {
        [SerializeField] private TextMeshProUGUI turretName;
        private TurretBehaviour turret;
        private Train train;
        
        public override void OnPanelDataChanged()
        {
            var trainSlot = (TrainSlot) ParentPanel.GetDataAsType<PanelDataBase>().Data;
            turret = trainSlot.TurretAttached.TurretBehaviour;
            train = trainSlot.Train;
            turretName.text = turret.name;
        }
        
        public void UpgradeDamage()
        {
            turret.UpgradeDamage();
            ParentPanel.PanelActionsFragment.CloseThisPanel();
            train.ExpController.RemoveUpgradePoint();
        }
        
        public void UpgradeAttackSpeed()
        {
            turret.UpgradeAttackSpeed();
            ParentPanel.PanelActionsFragment.CloseThisPanel();
            train.ExpController.RemoveUpgradePoint();
        }
    }
}
