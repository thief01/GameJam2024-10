using System;
using Character.General;
using UnityEngine;
using WRA_SDK.WRA.General;
using Zenject;

namespace General
{
    public class SceneObject : MonoBehaviour
    {
        [SerializeField] private SceneType sceneType;

        private GameManager gameManager;


        [Inject]
        private void InitGameManager(GameManagerBase gameManagerBase)
        {
            gameManager = (GameManager)gameManagerBase;
            gameManager.OnSceneChanged(sceneType);
        }
    }
}