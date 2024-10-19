using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Panels.PlayerView
{
    public class CoolBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI value;
        [SerializeField] private Image mainBar;
        [SerializeField] private Image secondBar;

        [SerializeField] private float delayTime = 0.2f;
        [SerializeField] private float fillSpeed = 0.5f;
        
        private float targetValue = 1;

        private float currentDelayTime = 0;

        private void Update()
        {
            mainBar.fillAmount = Mathf.MoveTowards(mainBar.fillAmount, targetValue, fillSpeed * Time.deltaTime);

            if (Mathf.Approximately(mainBar.fillAmount, secondBar.fillAmount))
            {
                currentDelayTime = delayTime;
            }

            if (currentDelayTime > 0)
            {
                currentDelayTime -= Time.deltaTime;
                return;
            }
            
            secondBar.fillAmount = Mathf.MoveTowards(secondBar.fillAmount, mainBar.fillAmount, fillSpeed * Time.deltaTime);
        }


        public void SetValue(float value, float maxValue)
        {
            if (maxValue == 0)
            {
                this.value.text = "0/0";
                targetValue = 1;
                return;
            }
            targetValue = value / maxValue;
            
            this.value.text = $"{value}/{maxValue}";
        }
    }
}
