using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckItemAvailableAction : ActionBase
{
    [SerializeField] private bool isAvailable;

    public override void DoAction()
    {
        if (isAvailable)
        {
            OnActionCompleted?.Invoke();
        }
    }

    public void SetAvailable(bool value)
    {
        isAvailable = value;
    }
}
