using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(_shopaholic.CanSeePlayer())
        {
            Debug.Log("Can see player");
            return NodeState.SUCCESS;

        }
        Debug.Log("Can't see player");
        return NodeState.FAILURE;
    }
}
