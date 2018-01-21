using Zenject;

public class CallSeenShopaholic : ShopaholicBTLeaf
{
    private ShopaholicsManager _shopaholicsManager;

    [Inject]
    public void Construct(ShopaholicsManager shopaholicsManager)
    {
        _shopaholicsManager = shopaholicsManager;
        return;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        Shopaholic visble = _shopaholicsManager.GetVisibleForShopaholic(_shopaholic);
        if (visble != null)
        {
            visble.BeCalled(_shopaholic);
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
