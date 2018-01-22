using UnityEngine;
using Zenject;

public class BehaviorHandler : IInitializable
{
    private BehaviorTree _tree = null;
    private BlackBoard _board = null;

    private AnimatorHandler _animatorHandler = null;

    [Inject]
    public BehaviorHandler(AnimatorHandler  animatorHandler)
    {
        _animatorHandler = animatorHandler;
        return;
    }
    
    public void Tick(Shopaholic shopaholic)
    {
        if(_board != null)
        {
            _tree.Tick(_board, shopaholic);
        }

        return;
    }

    public void Initialize()
    {
        CreateTree();
    }

    public void Idle()
    {
        _animatorHandler.StopAnimations();
    }

    public void FeelAgony()
    {
        _animatorHandler.SetAnimation(ShopaholicAnimations.Agony);
        return;
    }

    public void Die()
    {
        _animatorHandler.SetAnimation(ShopaholicAnimations.Die, true);
        return;
    }

    public void Run()
    {
        _animatorHandler.SetAnimation(ShopaholicAnimations.Running,true);
        return;
    }

    public void AttackPlayer()
    {
        _animatorHandler.SetAnimation(ShopaholicAnimations.Attack, true);
    }

    public bool IsAttacking()
    {
        return _animatorHandler.IsState(ShopaholicAnimations.Attack);
    }

    public float GetAttackProgress()
    {
        if(_animatorHandler.IsState(ShopaholicAnimations.Attack))
        {
            return _animatorHandler.GetAnimationProgress();
        }

        return 0.0f;
    }

    private void CreateTree()
    {
        _board = new BlackBoard();

        Node root = new PriorityNode(
            new SequenceNode(
                 new HasNoHealthPoints(),
                 new Die()
                ),
            new SequenceNode(
                 new IsClosePlayer(),
                 new IsSuffering(),
                 new FeelAgony()
                 ),
            new SequenceNode(
                  new IsNotHealthy(),
                  new MemSequnceNode(
                        new Escape(),
                        new GatherShopaholics(),
                        new ReturnOnLastPlaceWherePlayerSeen()
                        )
                 ),

            new PriorityNode(
                new SequenceNode(
                    new CanSeePlayer(),
                    new PriorityNode(
                        new SequenceNode(
                            new IsClosePlayer(),
                            new AttackPlayer()
                        ),
                        new SequenceNode(
                            new FollowPlayer(),
                            new CanSeeOtherShopaholic(),
                            new CallSeenShopaholic()
                        )
                    )
                ),
                new SequenceNode(
                    new PriorityNode(
                        new SequenceNode(
                            new IsCalled(),
                            new FollowShopaholic()
                         ),
                         new Idle()
                    )
                )
            )
        );

        _tree = new BehaviorTree(root);
    }
}
