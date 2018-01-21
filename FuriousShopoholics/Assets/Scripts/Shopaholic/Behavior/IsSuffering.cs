﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSuffering : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        if(_shopaholic.IsSufferingAttack())
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
