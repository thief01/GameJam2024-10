using Character.Controllers;
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
        
        [SerializeField] private int sellPrice = 50;
        [SerializeField] private int buyPrice = 100;
        [SerializeField] private int upgradePrice = 50;
        
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
            if(buyPrice > MoneyController.Instance.Money)
                return;
            MoneyController.Instance.RemoveMoney(buyPrice);
            var turret = turretPool.SpawnObject();
            turret.transform.SetParent(transform);
            turret.transform.position = transform.position;
            turretAttached = turret.GetComponent<TurretCharacter>();
            OnClick();
        }
        
        public void UpgradeTurret()
        {
            if(upgradePrice > MoneyController.Instance.Money)
                return;
            MoneyController.Instance.RemoveMoney(upgradePrice);
            turretAttached.Upgrade();
            OnClick();
        }
        
        public void RemoveTurret()
        {
            MoneyController.Instance.AddMoney(sellPrice);
            turretAttached.GetComponent<Turret>().Kill();
            turretAttached = null;
            OnClick();
        }
    }
}
