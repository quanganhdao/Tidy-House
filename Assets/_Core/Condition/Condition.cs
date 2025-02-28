using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Condition : ConditonBase
{
    public bool isMatch;

    [SerializeField] private UnityEvent onConditionMatched;
    public override bool IsMatch()
    {
        throw new System.NotImplementedException();
    }
    public void SetMatch(bool match)
    {
        isMatch = match;
        onConditionMatched?.Invoke();
    }

}
