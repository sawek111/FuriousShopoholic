using UnityEngine;
using System;
using Zenject;
using UnityEngine.AI;

public class ShopaholicInstaller : MonoInstaller<ShopaholicInstaller>
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.Bind<Navigator>().AsSingle().WithArguments(_settings._navMeshAgent);
        Container.BindInterfacesAndSelfTo<HealthHandler>().AsSingle().WithArguments(_settings._healthSettings);
        Container.BindInterfacesAndSelfTo<AnimatorHandler>().AsSingle().WithArguments(_settings._animator);

        //Container.Bind<Hex>().AsSingle().WithArguments(
        // _settings.Object,
        // _settings.Collider,
        // _settings.Randerer);

        return;
    }

    [Serializable]
    public class Settings
    {
        public NavMeshAgent _navMeshAgent;
        public Transform _transform;
        public Animator _animator;

        public HealthHandler.Settings _healthSettings;
    }
}