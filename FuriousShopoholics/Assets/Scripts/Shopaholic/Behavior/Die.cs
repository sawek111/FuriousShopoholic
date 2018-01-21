using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : Node
{
    public override NodeState ParticularTick(Tick tick)
    {
        return NodeState.ERROR;
    }
}
