using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Installers/GameSettings")]
public class GameSettings : ScriptableObjectInstaller<GameSettings>
{
    public MenuInstaller.Settings menuSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(menuSettings);
        return;
    }
}