using UnityEngine.AI;
using Zenject;

public class Navigator
{
    private NavMeshAgent _meshAgent = null;

    [Inject]
    public Navigator(NavMeshAgent meshAgent)
    {
        _meshAgent = meshAgent;
        return;
    }

    public void Update()
    {

    }
}
