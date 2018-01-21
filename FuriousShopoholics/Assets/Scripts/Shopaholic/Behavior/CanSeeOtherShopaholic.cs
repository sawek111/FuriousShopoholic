using Zenject;

public class CanSeeOtherShopaholic : ShopaholicBTLeaf
{
    private ShopaholicsManager _shopaholicsManager = null;

    [Inject]
    public void Construct(ShopaholicsManager shopaholicsManager)
    {
        _shopaholicsManager = shopaholicsManager;
        return;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        Shopaholic visble = _shopaholicsManager.GetVisibleForShopaholic(_shopaholic);
        if(visble != null)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
