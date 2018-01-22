﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopaholicsManager : IFixedTickable, IInitializable
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
        return;
    }

    public Shopaholic GetVisibleForShopaholic(Shopaholic shopaholic)
    {
        for(int i = 0; i < _shopaholics.Count; i++)
        {
            if(_shopaholics[i] == shopaholic)
            {
                continue;
            }
            if( Mathf.Abs( (_shopaholics[i].transform.position - shopaholic.transform.position).magnitude) < 15.5f && !_shopaholics[i].GetFollowedShopaholic() != shopaholic)
            {
                return _shopaholics[i];
            }
        }

        return null;
    }


    public int GetFollowing(Shopaholic shopaholic)
    {
        int count = 0;
        for (int i = 0; i < _shopaholics.Count; i++)
        {
            if (_shopaholics[i] == shopaholic)
            {
                continue;
            }
            if (Mathf.Abs((_shopaholics[i].transform.position - shopaholic.transform.position).magnitude) < 15.5f && !_shopaholics[i].GetFollowedShopaholic() != shopaholic)
            {
                count++;
            }
        }

        return count;
    }

    public void FixedTick()
    {
        UpdateShopaholics();
    }

    private void UpdateShopaholics()
    {
        for (int i = 0; i < _shopaholics.Count; i++)
        {
            if (!_shopaholics[i].IsDead())
            {
                _shopaholics[i].Tick();
                _shopaholics[i].NewVisible = GetVisibleForShopaholic((_shopaholics[i]));
                _shopaholics[i].FollowingCount = GetFollowing(_shopaholics[i]);
            }
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
