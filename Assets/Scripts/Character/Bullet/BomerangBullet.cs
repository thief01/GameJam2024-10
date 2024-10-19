using UnityEngine;

namespace Character.Bullet
{
    public class BomerangBullet : Pool.Objects.Bullet
    {
     
    

        protected override Vector3 GetTargetPosition()
        {
            return Vector3.zero;
        }
    }
}
