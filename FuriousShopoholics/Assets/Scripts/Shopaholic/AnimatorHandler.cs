using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnimatorHandler
{
    private Animator _animator = null;

    [Inject]
    public AnimatorHandler(Animator animator)
    {
        _animator = animator;
        return;
    }

    public bool IsState(ShopaholicAnimations animation)
    {
        return _animator.GetBool(animation.ToString());
    }

    public float GetAnimationProgress()
    {
        AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
        return info.normalizedTime;
    }

    public void StopAnimations()
    {
        for(int i = 0; i < Enum.GetNames(typeof(ShopaholicAnimations)).Length; i++)
        {
            _animator.SetBool(((ShopaholicAnimations)i).ToString(), false);
        }

        return;
    }

    public void SetAnimation(ShopaholicAnimations animation, bool stopOthers = false)
    {
        if(stopOthers)
        {
            StopAnimations();
        }
        _animator.SetBool(animation.ToString(), true);

        return;
    }
}
