using WRA.General.Patterns.Pool;

namespace Pool.Objects
{
    public class Turret : PoolObjectBase
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
