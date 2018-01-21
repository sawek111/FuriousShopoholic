using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnimatorHandler : IInitializable
{
    private Animator _animator = null;
    private AnimatorControllerParameter[] _animatorParameteres = null;

    [Inject]
    public AnimatorHandler(Animator animator)
    {
        _animator = animator;
        return;
    }

    public void Initialize()
    {
        _animatorParameteres = _animator.parameters;
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
        foreach (AnimatorControllerParameter parameter in _animatorParameteres)
        {
            _animator.SetBool(parameter.name, false);
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
