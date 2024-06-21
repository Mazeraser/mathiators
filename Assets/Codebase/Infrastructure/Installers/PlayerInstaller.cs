using Assets.Codebase.Mechanics.Character;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class PlayerInstallers : MonoInstaller
    {
        [SerializeField]
        private Player playerPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
        }
    }
}