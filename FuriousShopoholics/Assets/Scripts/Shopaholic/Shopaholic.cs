using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Shopaholic : MonoBehaviour
{
    private Navigator _navigator = null;
    private HealthHandler _healthHandler = null;

    [Inject]
    public void Construct(Navigator navigator, HealthHandler healthHandler)
    {
        _navigator = navigator;
        _healthHandler = healthHandler;

        return;
    }

    public bool HasHealthPoints()
    {
        return _healthHandler.HasHealthPoints();
    }

    void OnValidate()
    {
     
    }
}
