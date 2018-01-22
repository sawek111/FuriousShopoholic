using Zenject;
using UnityEngine;

public class CanSeeOtherShopaholic : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        Shopaholic visble = _shopaholic.NewVisible;
        if(visble != null)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
