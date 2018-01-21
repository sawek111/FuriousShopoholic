using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopaholicsManager : ITickable, IFixedTickable, IInitializable
{
    private Settings _settings = null;
    private Shopaholic.Pool _pool = null;

    private List<Shopaholic> _shopaholics = new List<Shopaholic>();

    [Inject]
    public ShopaholicsManager(Settings settings, Shopaholic.Pool pool)
    {
        _settings = settings;
        _pool = pool;

        return;
    }


    public void Initialize()
    {
        CreateStartShopaholics(_settings.ShopaholicsStartPool);
      
    }

    public void Tick()
    {
    }

    public void FixedTick()
    {
        UpdateShopaholics();
    }

    private void UpdateShopaholics()
    {
        for (int i = 0; i < _shopaholics.Count; i++)
        {
            _shopaholics[i].Tick();
        }

        return;
    }

    private void CreateStartShopaholics(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Shopaholic shopaholic = _pool.Spawn();
            _shopaholics.Add(shopaholic);
        }

        return;
    }

    [Serializable]
    public class Settings
    {
        public int ShopaholicsStartPool;
    }
}
