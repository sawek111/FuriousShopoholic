using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller>
{
    [Inject] private Settings _settings = null;

    public override void InstallBindings()
    {
        Container.BindMemoryPool<Shopaholic, Shopaholic.Pool>()
        .WithInitialSize(5)
        .FromSubContainerResolve()
        .ByNewPrefab(_settings.ShopaholicPrefab)
        .UnderTransformGroup("Shopaholics");

        Container.BindInterfacesAndSelfTo<ShopaholicsManager>().AsSingle().WithArguments(_settings.ShopaholicsManagerSettings).NonLazy();

        return;
    }

    [Serializable]
    public class Settings
    {
        public GameObject ShopaholicPrefab;
        public ShopaholicsManager.Settings ShopaholicsManagerSettings;
    }
}
