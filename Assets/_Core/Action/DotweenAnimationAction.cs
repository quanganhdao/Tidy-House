using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class DotweenAnimationAction : ActionBase
{
	[SerializeField] protected Transform animationTarget;
	[SerializeField] protected float duration;
	protected Tween tween;
	[SerializeField, Title("Ease Settings")] private bool useEase;
	[SerializeField, ShowIf("useEase")] private Ease easeType = Ease.Linear;
	[SerializeField, HideIf("useEase")] protected AnimationCurve animationCurve;

	public override void DoAction()
	{
		if (tween == null)
		{
			Debug.LogError("DotweenAnimationAction: Tween chưa được thiết lập!");
			return;
		}

		if (useEase)
		{
			tween.SetEase(easeType);
		}
		else
		{
			tween.SetEase(animationCurve);
		}

		tween.OnComplete(() =>
		{
			OnActionCompleted?.Invoke();
		});
	}
}