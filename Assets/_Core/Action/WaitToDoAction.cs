using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitToDoAction : ActionBase
{

    [SerializeField] private float secondToWait;
    public override void DoAction()
    {
        if (gameObject.activeSelf)
        {

            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(secondToWait);
        OnActionCompleted?.Invoke();
    }
}
