using Pool.Objects;
using UnityEngine;
using WRA.General.Patterns.Pool;
using Zenject;

namespace Pool.Spawners
{
    public class TrainSpawner : MonoBehaviour
    {
        public static Train Train { get; private set; } = null;
        
        [Inject] private PoolBase<Train> trainPool;
        
        public void SpawnTrain()
        {
            var spawnedTrain = trainPool.SpawnObject();
            spawnedTrain.transform.position = Vector3.zero;
            Train = spawnedTrain.GetComponent<Train>();
        }
    
    }
}
