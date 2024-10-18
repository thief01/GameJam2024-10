using Character.Controllers;
using TMPro;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class MoneyFragment : PanelFragmentBase
    {
        [SerializeField] private string goldText;
        [SerializeField] private TextMeshProUGUI moneyText;
    
        private MoneyController moneyController;

        private void Update()
        {
            if (moneyController == null)
                return;

            moneyText.text = goldText + moneyController.Money;

        }

        public override void OnPanelDataChanged()
        {
            var cho = (CharacterObject) ParentPanel.GetDataAsType<PanelDataBase>().Data;
            moneyController = cho.GetCharacterSystem<MoneyController>();
        }
    }
}
