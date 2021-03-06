﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Shopaholic : MonoBehaviour
{
    private Navigator _navigator = null;
    private HealthHandler _healthHandler = null;
    private BehaviorHandler _behaviorHandler = null;

    private Player _player = null;

    private Shopaholic _newVisible = null;
    private int _followingCount = 0;

    [Inject]
    public void Construct(Navigator navigator, HealthHandler healthHandler, BehaviorHandler behaviorHandler, Player player)
    {
        _navigator = navigator;
        _healthHandler = healthHandler;
        _behaviorHandler = behaviorHandler;
        _player = player;

        return;
    }

    public Shopaholic NewVisible
    {
        get { return _newVisible; }
        set { _newVisible = value; }
    }

    public int FollowingCount
    {
        get { return _followingCount; }
        set { _followingCount = value; }
    }

    public Transform Transform
    {
        get { return _navigator.Transform; }
    }

    public void Tick()
    {
        _behaviorHandler.Tick(this);
        return;
    }


    public bool IsSufferingAttack()
    {
        return _player.IsAttacking() && _navigator.IsClosePlayer();
    }


    #region Navigation

    public void FollowPlayer()
    {
        _navigator.FollowPlayer();
        _behaviorHandler.Run();

        return;
    }

    public void MoveRandomly()
    {
        _navigator.MoveRandomly();
        _behaviorHandler.Run();
    }

    public float GetRemainingDistance()
    {
        return _navigator.GetRemainingDistance();
    }

    public void BeCalled(Shopaholic callingShopaholic)
    {
        _navigator.BeCalled(callingShopaholic);
        _behaviorHandler.Run();

        return;
    }

    public bool CanSeePlayer()
    {
        return _navigator.CanSeePlayer();
    }

    public void RunTowards(Transform transform)
    {
        _behaviorHandler.Run();
        _navigator.RunTowards(transform.position);

        return;
    }

    public bool IsFarFromPlayer()
    {
        return _navigator.IsFarFromPlayer();
    }

    public bool IsClosePlayer()
    {
        return _navigator.IsClosePlayer();
    }

    public Shopaholic GetFollowedShopaholic()
    {
        return _navigator.GetFollowedShopaholic();
    }

    #endregion

    #region Behavior

    public void Idle()
    {
        _behaviorHandler.Idle();
        return;
    }

    public void FeelAgony()
    {
        _behaviorHandler.FeelAgony();
        return;
    }

    public void PunchPlayer()
    {
        _player.RemoveHealth(15);
        return;
    }

    public void AttackPlayer()
    {
        _behaviorHandler.AttackPlayer();
        return;
    }

    public float GetAttackProgress()
    {
        return _behaviorHandler.GetAttackProgress();
    }


  #endregion

    #region HealthHandler

    public int GetHealthPoints()
    {
        return _healthHandler.HealthPoints;
    }

    public int GetMaxHealthPoints()
    {
        return _healthHandler.MaxHealthPoints;
    }

    public void RegenerateHealth()
    {
        _healthHandler.RegenerateHealth();
        return;
    }

    public bool IsDead()
    {
        return _healthHandler.IsDead();
    }

    public void Die()
    {
        if (!_healthHandler.IsDead())
        {
            _healthHandler.Die();
            _behaviorHandler.Die();
        }

        return;
    }

    public void RemoveHealth(int points)
    {
        _healthHandler.RemoveHealthPoints(points);
    }

    public bool HasHealthPoints()
    {
        return _healthHandler.HasHealthPoints();
    }

#endregion

    #region MemoryPool
    public class Pool : MonoMemoryPool<Shopaholic>
    {

    }

#endregion

}
