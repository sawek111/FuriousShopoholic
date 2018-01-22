using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCalled : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(_shopaholic.GetFollowedShopaholic() == null || _shopaholic.GetFollowedShopaholic().IsDead())
        {
            return NodeState.FAILURE;
        }

        return NodeState.SUCCESS;
    }

}
