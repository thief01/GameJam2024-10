using System;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Character.Controllers
{
    public class MoneyController : CharacterSystemBase
    {
        public int Money
        {
            get => money;
            private set
            {
                money = value;
            }
        }
    
        [SerializeField] private int money = 100;

        [Inject] private PanelManager panelManager;
        private void Start()
        {
            panelManager.OpenPanel("PlayerView", new PanelDataBase() {Data = this});
        }

        public void AddMoney(int money)
        {
            Money += money;
        }
    
        public void RemoveMoney(int money)
        {
            Money -= money;
        }
    
        public bool CanBuy(int price)
        {
            return Money >= price;
        }
    }
}
