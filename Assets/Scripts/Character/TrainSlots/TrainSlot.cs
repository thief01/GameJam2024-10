using System;
using Character.Controllers;
using Interfaces;
using Panels;
using Pool.Objects;
using Pool.Spawners;
using UnityEngine;
using WRA.General.Patterns.Pool;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Character.TrainSlots
{
    public class TrainSlot : MonoBehaviour, IClickable
    {
        public Train Train => train;
        public TurretCharacter TurretAttached => turretAttached;
        public bool IsSelected => isSelected;
        
        [SerializeField] private int sellPrice = 50;
        [SerializeField] private int buyPrice = 100;
        [SerializeField] private int upgradePrice = 50;
        [SerializeField] private int startTurrret = -1;
        
        [Inject] private PoolBase<Turret> turretPool;
        [Inject] private PanelManager panelManager;
        
        private TurretCharacter turretAttached;
        private Train train;
        private bool isSelected;

        private void Start()
        {
            if (startTurrret != -1)
            {
                BuildTurret(startTurrret, false);
            }
        }

        public void SetTrain(Train train)
        {
            this.train = train;
        }

        public void OnClick(ClickData data)
        {
            train.TakeControl((GameControlls)data.Data, Array.IndexOf(train.TrainSlots, this));
        }

        public void SelectSlot()
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
            isSelected = true;
        }
        
        public void DeselectSlot()
        {
            panelManager.ClosePanel("TurretPanel");
            panelManager.ClosePanel("ShopPanel");
            isSelected = false;
        }
        
        public void BuildOrUpgradeTurret()
        {
            if (turretAttached == null)
            {
                BuildTurret();
                return;
            }

            UpgradeTurret();
        }
        
        private void BuildTurret(int id = 0, bool removeMoney = true)
        {
            if(buyPrice > train.MoneyController.Money)
                return;
            if(removeMoney)
                train.MoneyController.RemoveMoney(buyPrice);
            var turret = turretPool.SpawnObject(id);
            turret.transform.SetParent(transform);
            turret.transform.position = transform.position;
            turretAttached = turret.GetComponent<TurretCharacter>();
            SelectSlot();
        }
        
        private void UpgradeTurret()
        {
            if(train.ExpController.AvailableUpgradePoints <= 0)
                return;
            panelManager.OpenPanel("LevelUpPanelTurret", new PanelDataBase() { Data = this });
        }
        
        public void SellTurret()
        {
            train.MoneyController.AddMoney(sellPrice);
            turretAttached.GetComponent<Turret>().Kill();
            turretAttached = null;
            SelectSlot();
        }
    }
}
