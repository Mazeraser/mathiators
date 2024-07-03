using Assets.Codebase.UI;
using UnityEngine;
using Zenject;

public class FadeInstaller : MonoInstaller
{
    [SerializeField]
    private Fade fade;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Fade>().FromComponentInNewPrefab(fade).AsSingle().NonLazy();
    }
}