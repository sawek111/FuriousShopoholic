using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : ShopaholicBTLeaf
{
    private bool playerPunched = false;

    public override NodeState ParticularTick(Tick tick)
    {
        if (_shopaholic.IsAttacking())
        {
            if(_shopaholic.GetAttackProgress() > 0.9f  && !playerPunched)
            {
                _shopaholic.PunchPlayer();
                playerPunched = true;
                Debug.LogError("Punched");
            }
            _shopaholic.AttackPlayer();
            return NodeState.SUCCESS;
        }

        _shopaholic.AttackPlayer();
        playerPunched = false;
        return NodeState.SUCCESS;

    }
}
