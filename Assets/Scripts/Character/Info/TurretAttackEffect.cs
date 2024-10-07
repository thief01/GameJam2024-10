using System;
using System.Collections;
using Character.Behaviours;
using UnityEngine;

namespace Character.Info
{
    public class TurretAttackEffect : MonoBehaviour
    {
        [SerializeField] private TurretBehaviour turretBehaviour;
        [SerializeField] private float maxRecoil = 0.3f;
        [SerializeField] private float recoilSpeed = 5f;
        
        private bool isRecoiling;
        
        private Vector3 startPosition;
        private Vector3 maxRecoilPosition;

        private void Awake()
        {
            startPosition = transform.localPosition;
            turretBehaviour.OnShoot.AddListener(OnShoot);
        }

        private void Update()
        {
            if (!isRecoiling)
            {
                transform.localPosition = Vector3.Lerp(startPosition, maxRecoilPosition, turretBehaviour.AttackCooldownPercentage);
            }
        }

        private void OnShoot()
        {
            // StopAllCoroutines();
            // StartCoroutine(Recoil());
            maxRecoilPosition = -transform.forward * maxRecoil;
            transform.localPosition = maxRecoilPosition;
        }
        
        private IEnumerator Recoil()
        {
            isRecoiling = true;
            float recoil = 0;
            var maxRecoilPosition = -transform.forward * maxRecoil;
            while (recoil < maxRecoil)
            {
                recoil += recoilSpeed * Time.deltaTime;
                transform.localPosition = Vector3.Lerp(startPosition, maxRecoilPosition, recoil / maxRecoil);
                yield return null;
            }
            maxRecoilPosition = transform.localPosition;
            isRecoiling = false;
        }
    }
}
