using UnityEngine;

namespace Player
{
    public class PlayerInputBind : MonoBehaviour
    {
        private GameControlls gameControlls;
        
        private void Awake()
        {
            gameControlls = new GameControlls();
            gameControlls.General.LMB.performed += ctx => OnLeftClick();
            gameControlls.General.RMB.performed += ctx => OnRightClick();
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
    }
}
