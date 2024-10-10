using UnityEngine;
using WRA.CharacterSystems.StatisticsSystem.Controllers;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character.Effects
{
    public abstract class DamageEffectBase : MonoBehaviour
    {
        private HealthSystemBaseController healthSystemBaseController;
        private void Awake()
        {
            healthSystemBaseController = GetComponent<HealthSystemBaseController>();
            healthSystemBaseController.OnDamaged.AddListener(OnDamage);
        }

        protected abstract void OnDamage(DamageInfo damageInfo);
    }
}
