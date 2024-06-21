using Assets.Codebase.Mechanics.Timer;
using Zenject;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class TimerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Timer>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}