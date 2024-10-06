using System.Collections.Generic;
using Pool.Objects;
using UnityEngine;
using WRA.General.Patterns.Pool;
using WRA.Zenject.Pool;
using Zenject;

namespace Pool
{
    public class PoolInstaller : MonoInstaller
    { 
        private PoolBase<Bullet> bulletPool;
        
        private List<IPool> pools = new List<IPool>();
        
        [SerializeField] private ScriptableObject[] myScriptableObjects;
    
        public override void Start()
        {
            base.Start();
            bulletPool.poolObjectFactory = Container.Resolve<PoolObjectFactory>();

            for (int i = 0; i < myScriptableObjects.Length; i++)
            {
                Container.Inject(myScriptableObjects[i]);
            }
        }

        public override void InstallBindings()
        {
            bulletPool = new PoolBase<Bullet>();

            pools.Add(bulletPool);

        
            Container.Bind<PoolBase<Bullet>>().FromInstance(bulletPool);

            Container.Bind<List<IPool>>().FromInstance(pools);
        }
    }
}
