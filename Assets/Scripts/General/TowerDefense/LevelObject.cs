using Character.General;
using UnityEngine;
using WRA.General.Patterns.Pool;
using Zenject;

namespace General.TowerDefense
{
    public class LevelObject : PoolObjectBase
    {
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
