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
                 new HasNoHealthPoints()

                ),
            new SequenceNode(
                ),
            new SequenceNode(

                )
            );

        _tree = new BehaviorTree(root);
    }
}
