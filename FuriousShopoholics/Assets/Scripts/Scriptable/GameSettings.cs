using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Installers/GameSettings")]
public class GameSettings : ScriptableObjectInstaller<GameSettings>
{
    public MenuInstaller.Settings menuSettings;
    public GameplayInstaller.Settings gameplaySettings;

    public override void InstallBindings()
    {
        Container.BindInstance(menuSettings);
        Container.BindInstance(gameplaySettings);

        return;
    }
}