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

    public void SetAnimation(ShopaholicAnimations animation, bool stopOthers = false)
    {
        if(stopOthers)
        {
            foreach (AnimatorControllerParameter parameter in _animatorParameteres)
            {
                _animator.SetBool(parameter.name, false);
            }
        }
        _animator.SetBool(animation.ToString(), true);

        return;
    }
}
