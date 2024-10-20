using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public class FadeManagerMessageFragment : PanelFragmentBase
    {
        [SerializeField] private TextMeshProUGUI messageText;
        
        public override void OnPanelDataChanged()
        {
            messageText.text = ParentPanel.GetDataAsType<PanelDataBase>().Data.ToString();
        }
    }
}
