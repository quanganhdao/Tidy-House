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
