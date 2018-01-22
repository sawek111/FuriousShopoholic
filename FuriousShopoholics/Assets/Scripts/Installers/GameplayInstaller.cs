using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller>
{
    [Inject] private Settings _settings = null;

    public override void InstallBindings()
    {
        Container.Bind<HealthPanel>().FromComponentInNewPrefab(_settings.MenuPanelPrefab).AsSingle().NonLazy();

        Container.BindMemoryPool<Shopaholic, Shopaholic.Pool>()
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

        public GameObject MenuPanelPrefab;
    }
}
