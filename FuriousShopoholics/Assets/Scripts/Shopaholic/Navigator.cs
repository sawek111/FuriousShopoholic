using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Navigator
{
    private Settings _settings = null;


    private NavMeshAgent _meshAgent = null;
    private Transform _transform = null;

    private Player _player;
    private BehaviorHandler _behaviorHandler = null;

    private Shopaholic _shopaholicToFollow = null;
    private Vector3 _playerLastPosition = Vector3.zero;


    [Inject]
    public Navigator(Settings settings, NavMeshAgent meshAgent, Transform transform, Player player, BehaviorHandler behaviorHandler)
    {
        _settings = settings;
        _meshAgent = meshAgent;
        _player = player;
        _transform = transform;
        _behaviorHandler = behaviorHandler;

        return;
    }

    public Shopaholic GetFollowedShopaholic()
    {
        return _shopaholicToFollow;
    }

    public void BeCalled(Shopaholic calling)
    {
        _shopaholicToFollow = calling;
        return;
    }

    public void RunTowards(Vector3 position)
    {
        _meshAgent.SetDestination(position);
        return;
    }

    public void MoveRandomly()
    {
        while(true)
        {
            float x = UnityEngine.Random.Range(-40.0f, 40.0f);
            float z = UnityEngine.Random.Range(-40.0f, 40.0f);

            if (_meshAgent.SetDestination(Utils.GetVector(x, 0.0f, z)))
            {
                break;
            }
        }
    }

    public float GetRemainingDistance()
    {
        return _meshAgent.remainingDistance;
    }

    public bool IsClosePlayer()
    {
        return _settings.CloseDistance >= Mathf.Abs((_player.GetMovingTransform().position - _transform.position).magnitude);
    }

    public bool IsFarFromPlayer()
    {
        return Mathf.Abs((_player.GetMovingTransform().position - _transform.position).magnitude) >= _settings.DetectionDistance;
    }

    public bool CanSeePlayer()
    {
        Vector3 front = _transform.forward;
        Vector3 playerPos = _player.GetMovingTransform().position;
        float angle = Vector3.Angle(front, playerPos);
        float distance = Mathf.Abs((playerPos - _transform.position).magnitude);

        if(distance < _settings.DetectionDistance && angle < _settings.DetectionAngle)
        {
            return true;
        }

        return false;
    }

    public void FollowPlayer()
    {
        _meshAgent.SetDestination(_player.GetMovingTransform().position);
        _playerLastPosition = _player.GetMovingTransform().position;

        return;
    }

    [Serializable]
    public class Settings
    {
        public int DetectionDistance;
        public float CloseDistance;
        public float DetectionAngle;
    }

}
