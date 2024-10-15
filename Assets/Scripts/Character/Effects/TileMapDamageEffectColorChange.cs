using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using WRA.CharacterSystems.StatisticsSystem.ResourcesInfos;

namespace Character.Effects
{
    public class TileMapDamageEffectColorChange : DamageEffectBase
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Color damageColor;
        
        protected override void OnDamage(DamageInfo damageInfo)
        {
            tilemap.color = damageColor;
            StartCoroutine(ResetColor());
        }
        
        private IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(0.1f);
            tilemap.color = Color.white;
        }
    }
}
