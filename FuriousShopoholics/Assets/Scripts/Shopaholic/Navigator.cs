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

    [Inject]
    public Navigator(Settings settings, NavMeshAgent meshAgent, Transform transform, Player player)
    {
        _settings = settings;
        _meshAgent = meshAgent;
        _player = player;
        _transform = transform;

        return;
    }

    public bool IsClosePlayer()
    {
        return _settings.CloseDistance >= Mathf.Abs((_player.GetMovingTransform().position - _transform.position).magnitude);
    }

    public bool CanSeePlayer()
    {
        Vector3 front = _transform.forward;
        Vector3 playerPos = _player.GetMovingTransform().position;
        float angle = Vector3.Angle(front, playerPos);
        float distance = Mathf.Abs((playerPos - _transform.position).magnitude);
        Debug.LogWarning("Angle = " + angle + "distance " + distance);

        if(distance < _settings.DetectionDistance && angle < _settings.DetectionAngle)
        {
            return true;
        }

        return false;
    }

    public void Update()
    {

    }

    [Serializable]
    public class Settings
    {
        public int DetectionDistance;
        public float CloseDistance;
        public float DetectionAngle;
    }

}
