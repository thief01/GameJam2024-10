using Pool.Spawners;
using UnityEngine;
using WRA_SDK.WRA.General;

namespace Character.General
{
    public class GameManager : GameManagerBase
    {
        [SerializeField] private TrainSpawner trainSpawner;
        
        private void Start()
        {
            trainSpawner.SpawnTrain();
        }
    }
}
