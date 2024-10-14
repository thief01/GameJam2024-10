using Character.TrainSlots;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class TurretInfoPanel : InfoPanelBase
    {
        private TrainSlot trainSlot;

        public void Sell()
        {
            trainSlot.SellTurret();
        }

        public void Upgrade()
        {
            
        }
        
        protected override void UpdatePanelData()
        {
            trainSlot = (TrainSlot)ParentPanel.GetDataAsType<PanelDataBase>().Data;
            title.text = trainSlot.name + " - " + trainSlot.TurretAttached.name;
        }
    }
}
