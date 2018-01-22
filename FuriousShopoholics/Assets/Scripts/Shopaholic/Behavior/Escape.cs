using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(_shopaholic.GetRemainingDistance() < 3.0f)
        {
            if(_shopaholic.IsFarFromPlayer())
            {
                Debug.LogWarning("Escaped");
                return NodeState.SUCCESS;
            }
            _shopaholic.MoveRandomly();
        }

        return NodeState.RUNNING;
    }
}
