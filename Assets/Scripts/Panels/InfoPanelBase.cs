using TMPro;
using UnityEngine;
using WRA.UI.PanelsSystem;

namespace Panels
{
    public abstract class InfoPanelBase : PanelFragmentBase
    {
        [SerializeField] protected TextMeshProUGUI title;
        public override void OnPanelDataChanged()
        {
            UpdatePanelData();
        }
        
        protected abstract void UpdatePanelData();
    }
}
