using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        _shopaholic.FollowPlayer();
        Debug.LogWarning("Follow");
        return NodeState.SUCCESS;
    }
}
