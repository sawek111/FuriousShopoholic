using UnityEngine;

public class GatherShopaholics : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(_shopaholic.FollowingCount >= 3)
        {
            _shopaholic.RegenerateHealth();
            Debug.Log("Team completed");
            return NodeState.SUCCESS;
        }

        if(_shopaholic.GetRemainingDistance() < 1.0f)
        {
            _shopaholic.MoveRandomly();
        }

        Shopaholic visble = _shopaholic.NewVisible;
        if (visble != null)
        {
            visble.BeCalled(_shopaholic);
            Debug.Log("New found completed");
        }
        Debug.Log("Still Gathering");
        return NodeState.RUNNING;
    }

}
