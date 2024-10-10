using Character.Controllers;
using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class MoneyFragment : PanelFragmentBase
    {
        [SerializeField] private TextMeshProUGUI moneyText;
    
        private MoneyController moneyController;

        private void Update()
        {
            if (moneyController == null)
                return;
        
            moneyText.text = moneyController.Money.ToString();
        
        }

        public override void OnPanelDataChanged()
        {
            moneyController = (MoneyController) ParentPanel.GetDataAsType<PanelDataBase>().Data;
        }
    }
}
