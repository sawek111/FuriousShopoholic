using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClosePlayer : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if (_shopaholic.IsClosePlayer())
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
