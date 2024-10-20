using UnityEngine;
using WRA.General.Patterns.Pool;

namespace General.Rougelike
{
    public class MapFragment : PoolObjectBase
    {
        public MapFragmentAvailableTransitions availableTransitions;

        public override void OnInit()
        {
            
        }

        public override void OnSpawn()
        {
            gameObject.SetActive(true);
        }

        public override void OnBeginKill(float delay)
        {
           
        }

        public override void OnKill()
        {
            
        }
    }
}
