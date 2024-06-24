using UnityEngine;
using Zenject;
using Assets.Codebase.Infrastructure.Fabrics;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class EnemyFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyFactory _enemyFactoryPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyFactory>().FromComponentInNewPrefab(_enemyFactoryPrefab).AsSingle().NonLazy();
        }
    }
}