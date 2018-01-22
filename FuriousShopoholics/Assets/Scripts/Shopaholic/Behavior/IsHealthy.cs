using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsNotHealthy : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        float ratio = (float)_shopaholic.GetHealthPoints() / _shopaholic.GetMaxHealthPoints();
        if (ratio > 0.3f)
        {
            return NodeState.FAILURE;
        }
        return NodeState.SUCCESS;
    }

}
