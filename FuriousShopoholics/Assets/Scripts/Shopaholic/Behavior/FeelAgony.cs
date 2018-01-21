using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelAgony : ShopaholicBTLeaf
{
    private int counter;
    public override NodeState ParticularTick(Tick tick)
    {
        _shopaholic.FeelAgony();
        counter++;
        if(counter>5)
        {
            _shopaholic.RemoveHealth(5);
            counter = 0;
        }

        return NodeState.SUCCESS;
    }
}
