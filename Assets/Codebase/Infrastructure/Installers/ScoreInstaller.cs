using Assets.Codebase.Mechanics.EnemyScore;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class ScoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyScore>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}