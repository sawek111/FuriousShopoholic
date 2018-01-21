using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        _shopaholic.Die();
        return NodeState.SUCCESS;
    }
}
