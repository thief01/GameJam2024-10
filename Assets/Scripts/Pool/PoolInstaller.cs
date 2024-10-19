using System.Collections.Generic;
using General.TowerDefense;
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
        private PoolBase<Turret> turretPool;
        private PoolBase<Enemy> enemyPool;
        private PoolBase<Train> trainPool;
        private PoolBase<LevelObject> levelObjectPool;
        
        private List<IPool> pools = new List<IPool>();
        
        [SerializeField] private ScriptableObject[] myScriptableObjects;
    
        public override void Start()
        {
            base.Start();
            bulletPool.poolObjectFactory = Container.Resolve<PoolObjectFactory>();
            turretPool.poolObjectFactory = Container.Resolve<PoolObjectFactory>();
            enemyPool.poolObjectFactory = Container.Resolve<PoolObjectFactory>();
            trainPool.poolObjectFactory = Container.Resolve<PoolObjectFactory>();
            levelObjectPool.poolObjectFactory = Container.Resolve<PoolObjectFactory>();

            for (int i = 0; i < myScriptableObjects.Length; i++)
            {
                Container.Inject(myScriptableObjects[i]);
            }
        }

        public override void InstallBindings()
        {
            bulletPool = new PoolBase<Bullet>();
            turretPool = new PoolBase<Turret>();
            enemyPool = new PoolBase<Enemy>();
            trainPool = new PoolBase<Train>();
            levelObjectPool = new PoolBase<LevelObject>();

            pools.Add(bulletPool);
            pools.Add(turretPool);
            pools.Add(enemyPool);
            pools.Add(trainPool);
            pools.Add(levelObjectPool);
        
            Container.Bind<PoolBase<Bullet>>().FromInstance(bulletPool);
            Container.Bind<PoolBase<Turret>>().FromInstance(turretPool);
            Container.Bind<PoolBase<Enemy>>().FromInstance(enemyPool);
            Container.Bind<PoolBase<Train>>().FromInstance(trainPool);
            Container.Bind<PoolBase<LevelObject>>().FromInstance(levelObjectPool);

            Container.Bind<List<IPool>>().FromInstance(pools);
        }
    }
}
