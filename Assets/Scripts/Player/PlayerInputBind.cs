using Pool.Objects;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInputBind : MonoBehaviour
    {
        [Inject] private Train train;

        private GameControlls gameControlls;
        
        private void Awake()
        {
            gameControlls = new GameControlls();
            gameControlls.TowerDefense.LMB.performed += ctx => OnLeftClick();
            gameControlls.TowerDefense.RMB.performed += ctx => OnRightClick();
            gameControlls.TowerDefense.TurretSelect.performed += ctx => OnSelectTurret(0);
            gameControlls.TowerDefense.TurretSelect1.performed += ctx => OnSelectTurret(1);
            gameControlls.TowerDefense.TurretSelect2.performed += ctx => OnSelectTurret(2);
            gameControlls.TowerDefense.TurretSelect3.performed += ctx => OnSelectTurret(3);
            gameControlls.TowerDefense.BuyOrUpgrade.performed += ctx => BuyOrUpgrade();
            gameControlls.TowerDefense.Sell.performed += ctx => Sell();
            
            gameControlls.Enable();
        }
        
        private void OnLeftClick()
        {
            var mousePosition = Input.mousePosition;
            Debug.Log(mousePosition);
            var colliders = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(mousePosition));
            foreach (var collider in colliders)
            {
                var clickalbe = collider.GetComponent<IClickable>();
                if (clickalbe != null)
                {
                    clickalbe.OnClick();
                }
            }
        }
        
        private void OnRightClick()
        {
            
        }
        
        private void OnSelectTurret(int index)
        {
            train.SelectSlot(index);
        }
        
        private void BuyOrUpgrade()
        {
            var selectedSlot = train.SelectedSlot;
            if(selectedSlot == null)
                return;
            selectedSlot.BuildOrUpgradeTurret();
        }
        
        private void Sell()
        {
            var selectedSlot = train.SelectedSlot;
            if(selectedSlot == null)
                return;
            selectedSlot.SellTurret();
        }
    }
}
