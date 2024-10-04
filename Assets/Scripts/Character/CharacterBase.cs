using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using WRA.CharacterSystems;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character
{
    public abstract class CharacterBase : CharacterSystemBase, ICharacter, IPoolObject
    {
        public UnityEvent<IPoolObject> OnKillEvent;
        public UnityEvent<IPoolObject> OnSpawnEvent;
    
        public abstract void Move(Vector2 direction);

        public abstract void UseSkill(int skillIndex);

        public abstract void UpdateMousePosition(Vector2 mousePosition);
        public int VariantId { get; set; }
    
        public abstract void OnInit();
        
        public abstract void OnSpawn();

        public abstract void OnBeginKill(float delay);
        
        public abstract void OnKill();
        
        public void Spawn()
        {
            OnSpawn();
            SetActive(true);
        }
    
        public void Kill()
        {
            OnKill();
            SetActive(false);
            StopAllCoroutines();
            OnKillEvent?.Invoke(this);
        }

        public void Kill(float delay)
        {
            OnBeginKill(delay);
            StartCoroutine(KillDelay(delay));
        }

        public virtual void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        private IEnumerator KillDelay(float delay)
        {
            float time = 0;
            while (time < delay)
            {
                time += Time.deltaTime;
                yield return null;
            }
            Kill();
        }

        public virtual void Kill(KillInfo killInfo)
        {
            Kill();
        }
    }
}
