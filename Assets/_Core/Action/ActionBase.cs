
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActionBase : MonoBehaviour
{
	[SerializeField] protected UnityEvent OnActionCompleted;

	[Button]
	public abstract void DoAction();
}