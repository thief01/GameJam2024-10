using Pool.Objects;
using UnityEngine;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Spawners
{
    public class TrainSpawner : MonoBehaviour
    {
        [Inject] private PoolBase<Train> trainPool;
        
        private void Start()
        {
            SpawnTrain();
        }
        
        private void SpawnTrain()
        {
            var spawnedTrain = trainPool.SpawnObject();
            spawnedTrain.transform.position = Vector3.zero;
        }
    
    }
}
