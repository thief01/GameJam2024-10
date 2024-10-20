using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General;
using General.TowerDefense;
using Pool.Spawners;
using UnityEngine;
using WRA_SDK.WRA.General;
using WRA.General.Patterns.Pool;
using WRA.UI.PanelsSystem;
using WRA.UI.PanelsSystem.FadeSystem;
using Zenject;

namespace Character.General
{
    public class GameManager : GameManagerBase
    {
        public int LeftEnemies => spawners.Sum(ctg => ctg.LeftEnemies);
        public SceneType SceneType { get; private set; }
        [SerializeField] private TrainSpawner trainSpawner;

        [Inject] private PoolBase<LevelObject> levelObjectPool;
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
                    trainSpawner.RemoveTrain();
                    panelManager.OpenPanel("MainMenuPanel");
                    break;
                case SceneType.gameScene:
                    trainSpawner.SpawnTrain();
                    fadeManager = panelManager.OpenPanel("FadeManager") as FadeManager;
                    fadeManager.SetData(new PanelDataBase() { Data = "TEST"});
                    fadeManager.SetFadeAlpha(1);
                    fadeManager.FadeIn();
                    break;
            }
            SceneType = sceneType;
        }


        public void StartLevel(int levelId = 0)
        {
            fadeManager.FadeIn(OnEndFadeIn);
            levelObjectPool.SpawnObject(levelId);
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
