using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character.Effects
{
    public abstract class DamageEffectBase : MonoBehaviour
    {
        [SerializeField] private HealthSystemBaseController healthSystemBaseController;
        
        private void Awake()
        {
            healthSystemBaseController.OnDamaged.AddListener(OnDamage);
        }

        protected abstract void OnDamage(DamageInfo damageInfo);
    }
}
