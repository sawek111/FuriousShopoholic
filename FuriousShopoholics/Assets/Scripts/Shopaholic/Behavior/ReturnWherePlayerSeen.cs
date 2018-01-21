using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnOnLastPlaceWherePlayerSeen : ShopaholicBTLeaf
{
    private bool _returned = false;

    public override NodeState ParticularTick(Tick tick)
    {
        if (!_returned)
        {
            _shopaholic.FollowPlayer();
           _returned = _shopaholic.GetRemainingDistance() <= 2.0f;
            if(_returned)
            {
                return NodeState.SUCCESS;
            }
        }

        return NodeState.RUNNING;
    }
}
