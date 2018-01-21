using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Shopaholic : MonoBehaviour
{
    private Navigator _navigator = null;
    private HealthHandler _healthHandler = null;
    private AnimatorHandler _animatorHandler = null;

    private bool _dead = false;

    [Inject]
    public void Construct(Navigator navigator, HealthHandler healthHandler, AnimatorHandler animatorHandler)
    {
        _navigator = navigator;
        _healthHandler = healthHandler;
        _animatorHandler = animatorHandler;

        return;
    }

    public bool CanSeePlayer()
    {
        //TODO implement
        return false;
    }

#region HealthHandler

    public int GetHealthPoints()
    {
        return _healthHandler.HealthPoints;
    }

    public int GetMaxHealthPoints()
    {
        return _healthHandler.MaxHealthPoints;
    }

    public void Die()
    {
        if (!_healthHandler.IsDead())
        {
            _healthHandler.Die();
            _animatorHandler.SetAnimation(ShopaholicAnimations.Die, true);
        }

        return;
    }

    public bool HasHealthPoints()
    {
        return _healthHandler.HasHealthPoints();
    }

#endregion

    void OnValidate()
    {
     
    }
}
