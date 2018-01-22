using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region BehaviorTree
public enum NodeState
{
    SUCCESS,
    FAILURE,
    RUNNING,
    ERROR
}

public enum NodeType
{
    COMPOSITE,
    DECORATOR,
    LEAF,
    ROOT
}

public enum LeafType
{
    CONDITION,
    ACTION
}

public enum MemoryKeys
{
    OPEN_NODES,
    NODES_COUNT
}
#endregion

public enum ShopaholicAnimations
{
    Running,
    Attack,
    Agony,
    Die
}

