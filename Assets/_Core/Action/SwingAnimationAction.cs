using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector; // Nếu bạn dùng Odin Inspector

public class SwingAnimationAction : DotweenAnimationAction
{
	[Title("Swing Settings")]
	[SerializeField] private Transform pivot;

	[SerializeField, Range(10f, 90f)]
	private float swingAngle = 30f;

	[SerializeField, Range(0.1f, 20f)]
	private int swingCount;

	public override void DoAction()
	{
		if (pivot == null)
		{
			Debug.LogError("SwingAnimationAction: Chưa gán Pivot!");
			return;
		}

		animationTarget.SetParent(pivot); // Đảm bảo vật thể xoay quanh pivot

		// Xoay qua phải rồi xoay ngược lại
		tween = pivot.
		DORotate(new Vector3(0, 0, pivot.rotation.z - swingAngle), duration / (swingCount * 2)).
		From(new Vector3(0, 0, pivot.rotation.z + swingAngle)).
		SetLoops(swingCount, LoopType.Yoyo).
		OnComplete(() =>
		{
			OnActionCompleted?.Invoke();
			Debug.Log("Swing Ended");
		});

	}

	private void Reset()
	{
		swingAngle = 30f;
	}

	private void OnDrawGizmosSelected()
	{
		if (pivot == null || animationTarget == null) return;

		Gizmos.color = Color.cyan;
		Vector3 pivotPos = pivot.position;

		// Vẽ hướng ban đầu
		Vector3 dir = animationTarget.position - pivotPos;
		Gizmos.DrawLine(pivotPos, pivotPos + dir);

		// Vẽ góc xoay
		Quaternion leftRot = Quaternion.Euler(0, 0, -swingAngle);
		Quaternion rightRot = Quaternion.Euler(0, 0, swingAngle);

		Gizmos.DrawLine(pivotPos, pivotPos + leftRot * dir);
		Gizmos.DrawLine(pivotPos, pivotPos + rightRot * dir);
	}
}
