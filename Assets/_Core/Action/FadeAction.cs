using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class FadeAction : DotweenAnimationAction
{
    [SerializeField] private Image image;
    [SerializeField] private float opacity;

    public override void DoAction()
    {
        image.DOFade(opacity, duration).OnComplete(() =>
        {
            OnActionCompleted?.Invoke();
        });
        base.DoAction();
    }
}
