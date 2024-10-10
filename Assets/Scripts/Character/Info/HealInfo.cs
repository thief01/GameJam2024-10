using System;
using UnityEngine;
using UnityEngine.UI;
using WRA.CharacterSystems.StatisticsSystem.Controllers;

namespace Character.Info
{
    public class HealInfo : MonoBehaviour
    {
        [SerializeField] private HealthSystemBaseController healthSystemBaseController;
        [SerializeField] private Transform info;
        [SerializeField] private Image fill;
        [SerializeField] private bool hideIfFull = true;

        private void Update()
        {
            var hasFull = healthSystemBaseController.PercentValue >= 1;
            var hide = hideIfFull && hasFull;
            info.gameObject.SetActive(!hide);
            
            fill.fillAmount = healthSystemBaseController.PercentValue;
        }
    }
}
