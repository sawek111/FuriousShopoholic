using System;
using Zenject;

public class HealthHandler : IInitializable
{
    private Settings _settings;

    private int _healthPoints;

    public HealthHandler(Settings settings)
    {
        _settings = settings;
        return;
    }

    public void Initialize()
    {
        RegenerateHealth();
        return;
    }

    public void RemoveHealthPoints(int healthPoints)
    {
        _healthPoints -= healthPoints;
        return;
    }

    public bool HasHealthPoints()
    {
        return _healthPoints > 0;
    }

    public void RegenerateHealth()
    {
        _healthPoints = _settings.MaxHealthPoints;
        return;
    }

    [Serializable]
    public class Settings
    {
        public int MaxHealthPoints;
    }
}
