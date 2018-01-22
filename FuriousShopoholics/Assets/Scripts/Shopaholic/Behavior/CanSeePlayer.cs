using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(_shopaholic.CanSeePlayer())
        {
            return NodeState.SUCCESS;

        }
        return NodeState.FAILURE;
    }
}
