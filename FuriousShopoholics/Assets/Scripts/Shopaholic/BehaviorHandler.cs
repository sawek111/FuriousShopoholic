using UnityEngine;
using Zenject;

public class BehaviorHandler : IInitializable
{
    private BehaviorTree _tree = null;
    private BlackBoard _board = null;

    [Inject]
    public BehaviorHandler()
    {

    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
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
                new CanSeePlayer(),
                new PriorityNode(
                    new SequenceNode(
                        new IsHealthy(),
                        new PriorityNode(
                            new SequenceNode(
                                //IsCloseToPlayer(),
                                new PriorityNode(
                                    new SequenceNode(
                                        //IsSuffering?
                                        //Agony,
                                        //SufferHP
                                        )
                                    //,Attack()
                                    )
                                ),
                            new SequenceNode(
                                //FollowPlayer
                                //CanSeeOtherAI?
                                //CallAI
                                )
                            )
                        ),
                    new MemSequnceNode(
                        //Escape
                        //Gather + on done regenerate health
                        //ReturnOnPlace
                        )
                    )
                ),
            new SequenceNode(
                new PriorityNode(
                    new SequenceNode(
                        //IsCalled,
                        //Follow calling
                        )
                        //,Idle()
                    )
                )
            );

        _tree = new BehaviorTree(root);
    }
}
