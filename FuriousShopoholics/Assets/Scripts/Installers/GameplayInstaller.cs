using System;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller>
{
    [Inject] private Settings _settings = null;

    public override void InstallBindings()
    {
       
    }

    [Serializable]
    public class Settings
    {

    }
}
