using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character
{
    public abstract class CharacterBase : CharacterSystemBase, ICharacter
    {
        public abstract void Move(Vector2 direction);

        public abstract void UseSkill(int skillIndex);

        public abstract void UpdateMousePosition(Vector2 mousePosition);
    }
}
