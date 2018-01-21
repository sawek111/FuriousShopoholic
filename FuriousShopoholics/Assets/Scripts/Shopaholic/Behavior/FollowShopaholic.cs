using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShopaholic : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        Shopaholic followed = _shopaholic.GetFollowedShopaholic();
        if(followed != null)
        {
            _shopaholic.RunTowards(followed.transform);
            if(_shopaholic.GetRemainingDistance() <= 0.7f)
            {
                return NodeState.FAILURE;
            }
            return NodeState.SUCCESS;
        }

        return NodeState.ERROR;
    }
}
