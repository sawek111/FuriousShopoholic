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
                return NodeState.SUCCESS;
                Debug.LogWarning("Escaped");
            }
            _shopaholic.MoveRandomly();
        }

        Debug.LogWarning("Escaping");
        return NodeState.RUNNING;
    }
}
