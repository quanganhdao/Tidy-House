
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActionBase : MonoBehaviour
{
	[SerializeField] protected UnityEvent OnActionCompleted;
	public abstract void DoAction();
}