using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class ScaleAction : MonoBehaviour
{
    [ShowInInspector] private float scaleFactor = 1;
    [SerializeField] private float scaleAmountEachStep;
    [SerializeField] private int count;
    [SerializeField] private float durationEachScale;
    [SerializeField] private int scaleCount;
    [SerializeField] private UnityEvent OnScaleEnough;
    // Start is called before the first frame update
    public void Scale()
    {
        if (count >= scaleCount) return;
        scaleFactor += scaleAmountEachStep;
        count++;
        transform.DOScale(new Vector3(scaleFactor, scaleFactor, transform.localScale.z), durationEachScale)
        .OnComplete(() =>
        {
            if (count >= scaleCount)
            {
                OnScaleEnough?.Invoke();
            }
        });
    }
}
