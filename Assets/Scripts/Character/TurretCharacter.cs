using System;
using Character.Behaviours;
using UnityEngine;

namespace Character
{
    public class TurretCharacter : CharacterBase
    {
        public TurretBehaviour TurretBehaviour { get; private set; }

        private void Awake()
        {
            TurretBehaviour = GetComponent<TurretBehaviour>();
        }

        public override void Move(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }

        public override void UseSkill(int skillIndex)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateMousePosition(Vector2 mousePosition)
        {
            throw new System.NotImplementedException();
        }
        
        public void Upgrade()
        {
            
        }
    }
}
