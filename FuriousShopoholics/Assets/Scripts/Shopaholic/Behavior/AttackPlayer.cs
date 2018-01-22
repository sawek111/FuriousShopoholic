using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : ShopaholicBTLeaf
{
    private float _timer = 0.0f;

    public override NodeState ParticularTick(Tick tick)
    {
        _shopaholic.AttackPlayer();
        _timer += Time.fixedDeltaTime;
        if(_timer > 1.0f)
        {
            if(_shopaholic.GetAttackProgress() > 0.2f)
            {
                _shopaholic.PunchPlayer();
            }
            _timer = 0.0f;
        }
       
        return NodeState.SUCCESS;
    }
}
