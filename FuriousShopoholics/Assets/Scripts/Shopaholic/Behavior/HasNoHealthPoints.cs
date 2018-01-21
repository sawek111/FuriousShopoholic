using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasNoHealthPoints : Node
{
    public override NodeState ParticularTick(Tick tick)
    {
        Shopaholic shopaholic = tick.Target as Shopaholic;
        if(shopaholic == null)
        {
            return NodeState.ERROR;
        }

        if(!shopaholic.HasHealthPoints())
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
