using Character.Behaviours;
using WRA.CharacterSystems;
using WRA.General.Patterns.Pool;

namespace Pool.Objects
{
    public class Turret : CharacterObject
    {
        public TurretBehaviour TurretBehaviour { get; private set; }

        public override void OnInit()
        {
            TurretBehaviour = GetComponent<TurretBehaviour>();
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
