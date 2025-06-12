using UnityEngine;
using Zenject;

public class BootSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LaunchSceneController>().AsSingle();
    }
}