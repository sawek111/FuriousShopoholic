using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHealthy : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        float ratio = (float)_shopaholic.GetHealthPoints() / _shopaholic.GetMaxHealthPoints();
        Debug.LogWarning("healthRatio = " + ratio.ToString());
        if (ratio > 0.3f)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }

}
