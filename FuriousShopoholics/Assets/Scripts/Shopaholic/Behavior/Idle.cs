using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        _shopaholic.Idle();

        return NodeState.SUCCESS;
    }
}
