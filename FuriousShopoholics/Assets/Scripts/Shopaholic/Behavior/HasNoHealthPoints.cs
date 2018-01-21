using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasNoHealthPoints : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(!_shopaholic.HasHealthPoints())
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
