using System;
using Zenject;

public class HealthHandler : IInitializable
{
    private Settings _settings;

    private int _healthPoints;
    private bool _dead = false;

    public int HealthPoints
    {
        get { return _healthPoints; }
    }

    public int MaxHealthPoints
    {
        get { return _settings.MaxHealthPoints; }
    }

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

    public void Die()
    {
        _dead = true;
    }

    /// <summary>
    /// Has been dying called already
    /// </summary>
    public bool IsDead()
    {
        return _dead;
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
