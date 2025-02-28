using DG.Tweening;
using UnityEngine;

public class MoveAnimationAction : DotweenAnimationAction
{
	[SerializeField] private Transform destination;

	public override void DoAction()
	{
		tween = animationTarget.DOMove(destination.position, duration);
		base.DoAction();
	}
}

public class DotweenAnimationAction : ActionBase
{
	[SerializeField] protected Transform animationTarget;
	[SerializeField] protected float duration;
	[SerializeField] protected AnimationCurve animationCurve;
	protected Tween tween;

	public override void DoAction()
	{
		tween.SetEase(animationCurve).OnComplete(() =>
		{
			OnActionCompleted?.Invoke();
		});
	}
}