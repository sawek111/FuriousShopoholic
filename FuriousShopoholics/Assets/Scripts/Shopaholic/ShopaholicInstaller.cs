using UnityEngine;
using System;
using Zenject;
using UnityEngine.AI;

public class ShopaholicInstaller : MonoInstaller<ShopaholicInstaller>
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.Bind<Navigator>().AsSingle().WithArguments(_settings.NavigatorSettings, _settings.NavMeshAgent, _settings.Transform);
        Container.BindInterfacesAndSelfTo<HealthHandler>().AsSingle().WithArguments(_settings.HealthSettings);
        Container.BindInterfacesAndSelfTo<AnimatorHandler>().AsSingle().WithArguments(_settings.Animator);
        Container.BindInterfacesAndSelfTo<BehaviorHandler>().AsSingle().NonLazy();

        return;
    }

    [Serializable]
    public class Settings
    {
        public NavMeshAgent NavMeshAgent;
        public Transform Transform;
        public Animator Animator;

        public HealthHandler.Settings HealthSettings;
        public Navigator.Settings NavigatorSettings;
    }
}