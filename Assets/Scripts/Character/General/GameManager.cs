using System;
using System.Collections;
using System.Collections.Generic;
using General;
using Pool.Spawners;
using UnityEngine;
using WRA_SDK.WRA.General;
using WRA.UI.PanelsSystem;
using WRA.UI.PanelsSystem.FadeSystem;
using Zenject;

namespace Character.General
{
    public class GameManager : GameManagerBase
    {
        public SceneType SceneType { get; private set; }
        [SerializeField] private TrainSpawner trainSpawner;

        [Inject] private PanelManager panelManager;
        
        private List<TDEnemySpawner> spawners = new List<TDEnemySpawner>();
        private FadeManager fadeManager;
        private MapScrolling mapScrolling;

        private void Awake()
        {
            mapScrolling = FindAnyObjectByType<MapScrolling>();
        }

        public void OnSceneChanged(SceneType sceneType)
        {
            switch (sceneType)
            {
                case SceneType.mainMenuScene:
                    panelManager.OpenPanel("MainMenuPanel");
                    break;
                case SceneType.testScene:
                    trainSpawner.SpawnTrain();
                    fadeManager = panelManager.OpenPanel("FadeManager") as FadeManager;
                    fadeManager.SetFadeAlpha(1);
                    StartLevel(LevelType.towerDefence);
                    break;
            }
            SceneType = sceneType;
        }


        public void StartLevel(LevelType levelType)
        {
            fadeManager.FadeIn(OnEndFadeIn);
        }
        
        public void AddSpawner(TDEnemySpawner spawner)
        {
            spawners.Add(spawner);
        }

        private void OnEndFadeIn()
        {
            StartCoroutine(DelayFadeOut());
        }
        
        private IEnumerator DelayFadeOut()
        {
            yield return new WaitForSeconds(1);
            fadeManager.FadeOut();
            yield return new WaitForSeconds(5);
            spawners.ForEach(ctg => ctg.StartSpawning());
            mapScrolling.StopScrolling();
        }
    }
}
