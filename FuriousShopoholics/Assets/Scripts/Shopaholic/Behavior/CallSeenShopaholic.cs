using UnityEngine;
using Zenject;

public class CallSeenShopaholic : ShopaholicBTLeaf
{
    public override NodeState ParticularTick(Tick tick)
    {
        Shopaholic visble = _shopaholic.NewVisible;
        if (visble != null)
        {
            if(visble.GetFollowedShopaholic() == null || visble.GetFollowedShopaholic().IsDead())
            {
                visble.BeCalled(_shopaholic);
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }
}
