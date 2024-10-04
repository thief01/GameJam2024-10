using UnityEngine;

public interface ICharacter
{
    void Move(Vector2 direction);
    
    void UseSkill(int skillIndex);
    
    void UpdateMousePosition(Vector2 mousePosition);
}
