using System;
using UnityEngine;
using WRA.CharacterSystems;

namespace Character.Controllers
{
    public class MoneyController : CharacterSystemBase
    {
        public static MoneyController Instance { get; private set; }
        
        public int Money { get; private set; }
    
        [SerializeField] private int startMoney = 100;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
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
