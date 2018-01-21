using Zenject;

public class GatherShopaholics : ShopaholicBTLeaf
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
        if(_shopaholicsManager.GetFollowing(_shopaholic) >= 3)
        {
            _shopaholic.RegenerateHealth();
            return NodeState.SUCCESS;
        }

        if(_shopaholic.GetRemainingDistance() < 1.0f)
        {
            _shopaholic.MoveRandomly();
        }

        Shopaholic visble = _shopaholicsManager.GetVisibleForShopaholic(_shopaholic);
        if (visble != null)
        {
            visble.BeCalled(_shopaholic);
        }

        return NodeState.RUNNING;
    }

}
