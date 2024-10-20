using Pool.Objects;
using UnityEngine;
using WRA.General.Patterns.Pool;
using WRA.UI.PanelsSystem;
using Zenject;

namespace Pool.Spawners
{
    public class TrainSpawner : MonoBehaviour
    {
        public static Train Train { get; private set; } = null;
        
        [Inject] private PoolBase<Train> trainPool;
        [Inject] private PanelManager panelManager;
        
        public void SpawnTrain()
        {
            var spawnedTrain = trainPool.SpawnObject();
            spawnedTrain.transform.position = Vector3.zero;
            Train = spawnedTrain.GetComponent<Train>();
            panelManager.OpenPanel("PlayerView", new PanelDataBase() {Data = Train});
        }

        public void RemoveTrain()
        {
            Train?.Kill();
            Train = null;
        }
    }
}
