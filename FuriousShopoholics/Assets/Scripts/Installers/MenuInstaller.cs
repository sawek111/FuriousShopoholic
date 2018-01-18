using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller<MenuInstaller>
{
    [Inject] private readonly Settings _settings = null;

    public override void InstallBindings()
    {
        Container.Bind<MenuPanel>().FromComponentInNewPrefab(_settings._menuPanelPrefab).AsSingle().NonLazy();
        return;
    }

    [Serializable]
    public class Settings
    {
        public GameObject _menuPanelPrefab;
    }
}
