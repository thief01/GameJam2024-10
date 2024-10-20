using System;
using System.Collections.Generic;
using Character.General;
using UnityEngine;
using UnityEngine.Serialization;
using WRA_SDK.WRA.General;
using Zenject;

namespace General
{
    public class MapScrolling : MonoBehaviour
    {
        [SerializeField] private bool isScrolling = false;
        [SerializeField] private bool startScrolling = false;
        [SerializeField] private float maxScrollSpeed = 1f;
        [SerializeField] private AnimationCurve startScrollSpeedCurve;
        [SerializeField] private AnimationCurve stopScrollSpeedCurve;
        [SerializeField] private List<Transform> scrollTransforms;
        
        [SerializeField] private Vector3 resetPosition;
        [SerializeField] private float resetDistance;

        private GameManager gameManager;
        
        private float currentScrollSpeed;
        private float delta = 0;

        private void Awake()
        {
            if (startScrolling)
            {
                StartScrolling();
            }
        }

        private void Update()
        {
            if (!isScrolling)
            {
                currentScrollSpeed = stopScrollSpeedCurve.Evaluate(delta) * maxScrollSpeed;
                delta -= Time.deltaTime;
            }
            else
            {
                currentScrollSpeed = startScrollSpeedCurve.Evaluate(delta) * maxScrollSpeed;
                delta += Time.deltaTime;
            }
            
            delta = Mathf.Clamp(delta, 0, 1);
            Scroll();
            ResetScroll();
        }

        [Inject]
        private void Construct(GameManagerBase gameManagerBase)
        {
            gameManager = gameManagerBase as GameManager;
        }
        
        public void StartScrolling()
        {
            isScrolling = true;
            delta = 0;
        }
        
        public void StopScrolling()
        {
            isScrolling = false;
            delta = 1;
        }
        
        public void SetScrollSpeed(float speed)
        {
            maxScrollSpeed = speed;
        }
        
        private void Scroll()
        {
            for (int i = 0; i < scrollTransforms.Count; i++)
            {
                scrollTransforms[i].position += Vector3.left * currentScrollSpeed * Time.deltaTime;
            }
        }
        
        private void ResetScroll()
        {
            for (int i = 0; i < scrollTransforms.Count; i++)
            {
                if (scrollTransforms[i].localPosition.x < resetDistance)
                {
                    scrollTransforms[i].localPosition = resetPosition;
                }
            }
        }
    }
}
