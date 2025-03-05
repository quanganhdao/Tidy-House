using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SetRotationAction : DotweenAnimationAction
{
    [SerializeField]
    private Vector3 rotation
    ;
    public override void DoAction()
    {
        tween = animationTarget.DORotate(rotation, duration);
    }
}
