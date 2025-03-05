using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [ShowInInspector] private int count;
    [SerializeField] private int threshold;

    [SerializeField] private UnityEvent OnThresholdReached;

    public void Increase(int amount = 1)
    {
        count += amount;
        if (count == threshold)
        {
            OnThresholdReached?.Invoke();
        }
    }
}
