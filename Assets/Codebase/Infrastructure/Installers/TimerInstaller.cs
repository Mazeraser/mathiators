using Assets.Codebase.Mechanics.Timer;
using Zenject;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class TimerInstaller : MonoInstaller
    {
        [SerializeField]
        private Timer _timer;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Timer>().FromComponentInNewPrefab(_timer).AsSingle().NonLazy();
        }
    }
}