using UnityEngine;
using Zenject;
using Assets.Codebase.Infrastructure.Fabrics;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class EnemyFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyFactory>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}