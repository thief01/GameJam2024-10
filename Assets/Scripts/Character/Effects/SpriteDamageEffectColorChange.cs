using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character.Effects
{
    public class SpriteDamageEffectColorChange : DamageEffectBase
    {
        [SerializeField] private Tilemap spriteRenderer;
        [SerializeField] private Color damageColor;
        
        protected override void OnDamage(DamageInfo damageInfo)
        {
            spriteRenderer.color = damageColor;
            StartCoroutine(ResetColor());
        }
        
        private IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }
    }
}
