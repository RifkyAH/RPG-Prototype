using UnityEngine;
using Zenject;

public class BootSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LaunchSceneController>().AsSingle();
        Container.Bind<FadeOverlay>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerControlBinder>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameControlBinder>().FromComponentInHierarchy().AsSingle();
    }
}