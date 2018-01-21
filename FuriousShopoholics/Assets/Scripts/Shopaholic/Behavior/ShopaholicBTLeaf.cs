using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopaholicBTLeaf : Node
{
    protected Shopaholic _shopaholic = null;

    public override void ParticualEnter(Tick tick)
    {
        _shopaholic = tick.Target as Shopaholic;
        if(_shopaholic == null)
        {
            Debug.LogError("Sth does not working + " + this.ToString());
        }

        return;
    }
}