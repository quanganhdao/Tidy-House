using System.Collections;
using System.Collections.Generic;
using ScratchCardAsset;
using UnityEngine;
using UnityEngine.Events;

public class EraseProgressEventRegister : MonoBehaviour
{
    [SerializeField] private float interval = 0.1f;
    [SerializeField] private EraseProgress eraseProgress;
    [SerializeField] private UnityEvent<float> OnProgressChanged;
    private float currentValue = 0;

    void Awake()
    {
        eraseProgress.OnProgress += ProgressChanged;
    }

    private void ProgressChanged(float value)
    {
        if ((1 - value) - interval > currentValue)
        {
            OnProgressChanged?.Invoke(value);
            currentValue = (1 - value);
        }
    }
}
