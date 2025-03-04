using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq; // Odin Inspector

public class MoveAnimationAction : DotweenAnimationAction
{
	[SerializeField] private Transform destination;

	// [Title("Path Settings")]
	[SerializeField] private bool usePath = false;

	// [ShowIf("usePath")]
	private Transform[] pathPoints;
	Vector3[] path;
	[SerializeField, /* ShowIf("usePath") */] private Transform pointContainer;

	// [ShowIf("usePath")]
	[SerializeField] private bool isClosedPath = false;
	[SerializeField] private Color gizmoColor = Color.green;


	public override void DoAction()
	{
		if (usePath && pathPoints != null && pathPoints.Length > 0)
		{
			path[0] = animationTarget.position;
			path[path.Length - 1] = destination.position;
			tween = animationTarget.DOPath(path, duration, PathType.CatmullRom, PathMode.Full3D)
				.SetEase(animationCurve)
				.SetOptions(isClosedPath)
				.OnComplete(() => OnActionCompleted?.Invoke());
		}
		else
		{
			tween = animationTarget.DOMove(destination.position, duration)
				.SetEase(animationCurve).SetOptions(true)
				.OnComplete(() => OnActionCompleted?.Invoke());
		}

		base.DoAction();
	}

	private void Awake()
	{
		if (!usePath) return;
		pathPoints = pointContainer.GetComponentsInChildren<Transform>().Skip(1).ToArray();
		path = new Vector3[pathPoints.Length + 2];

		for (int i = 0; i < pathPoints.Length; i++)
		{
			path[i + 1] = pathPoints[i].position;
		}
	}

	private void OnDrawGizmosSelected()
	{
		ProcressGizmos();
	}

	void OnDrawGizmos()
	{
		ProcressGizmos();
	}

	void ProcressGizmos()
	{
		if (!usePath || pathPoints == null || pathPoints.Length == 0 || animationTarget == null || destination == null)
			return;

		Gizmos.color = gizmoColor;
		path[path.Length - 1] = destination.position;
		for (int i = 1; i < path.Length - 1; i++)
		{
			Gizmos.DrawLine(path[i], path[i + 1]);
		}
		// Gizmos.DrawLine(path[path.Length - 1], destination.position);

		if (isClosedPath)
		{
			Gizmos.DrawLine(destination.position, animationTarget.position);
		}
	}
}
