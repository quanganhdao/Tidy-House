using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallMethodIntervalAction : ActionBase
{

    [SerializeField] private float interval;
    [SerializeField] private UnityEvent ActionToDo;

    public override void DoAction()
    {
        StartCoroutine(CallMethodInterval());
    }

    private IEnumerator CallMethodInterval()
    {
        while (true)
        {
            ActionToDo?.Invoke();
            yield return new WaitForSeconds(interval);
        }
    }
}
