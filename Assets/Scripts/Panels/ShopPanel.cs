using Character;
using Character.TrainSlots;
using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class ShopPanel : InfoPanelBase
    {
        
        private TrainSlot trainSlot;
        
        public void OnBuyClick()
        {
            trainSlot.BuildOrUpgradeTurret();
        }
        
        protected override void UpdatePanelData()
        {
            trainSlot = (TrainSlot)ParentPanel.GetDataAsType<PanelDataBase>().Data;
            title.text = trainSlot.name + " - " + "null";
        }
    }
}
