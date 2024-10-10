using Panels;
using Pool.Objects;
using UnityEngine;
using WRA.General.Patterns.Pool;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Character.TrainSlots
{
    public class TrainSlot : MonoBehaviour, IClickable
    {
        public TurretCharacter TurretAttached => turretAttached;
        
        [Inject] private PoolBase<Turret> turretPool;
        [Inject] private PanelManager panelManager;
        
        private TurretCharacter turretAttached;
        
        public void OnClick()
        {
            var openedPanel = panelManager.GetPanels().Find(ctg => ctg.Fragments.Exists(ctg2 =>  ctg2 is InfoPanelBase) );
            if(openedPanel!=null)
                panelManager.ClosePanel(openedPanel.name);
            
            var panelToOpen = "TurretPanel";
            if (turretAttached == null)
            {
                panelToOpen = "ShopPanel";
            }
            panelManager.OpenPanel(panelToOpen, new PanelDataBase() { Data = this});
        }
        
        public void AddTurret()
        {
            var turret = turretPool.SpawnObject();
            turret.transform.SetParent(transform);
            turret.transform.position = transform.position;
            turretAttached = turret.GetComponent<TurretCharacter>();
            OnClick();
        }
        
        public void RemoveTurret()
        {
            turretAttached.GetComponent<Turret>().Kill();
            turretAttached = null;
            OnClick();
        }
    }
}
