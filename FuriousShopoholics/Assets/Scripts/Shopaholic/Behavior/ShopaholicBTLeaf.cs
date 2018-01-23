using System;

public class ShopaholicBTLeaf : Node
{
    protected Shopaholic _shopaholic = null;

    public override void ParticualEnter(Tick tick)
    {
        _shopaholic = tick.Target as Shopaholic;
        if(_shopaholic == null)
        {
            throw new Exception("Is not shopaholic");
        }

        return;
    }
}