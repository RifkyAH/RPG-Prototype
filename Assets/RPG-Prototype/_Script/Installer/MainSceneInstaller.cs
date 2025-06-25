using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerStateController>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerStateModel>().AsSingle();
        Container.Bind<PlayerStateManager>().FromComponentInHierarchy().AsSingle();
    }
}