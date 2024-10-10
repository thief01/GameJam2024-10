using System;
using UnityEngine;
using WRA.CharacterSystems;

namespace Character.Controllers
{
    public class MoneyController : CharacterSystemBase
    {
        public int Money { get; private set; }
    
        [SerializeField] private int startMoney = 100;
        
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
