using ScratchCardAsset;
using UnityEngine;
using UnityEngine.Events;
using static ScratchCardAsset.ScratchCard;

public class AutoCompleteScratchCardAction : MonoBehaviour
{
    [SerializeField] private ScratchCard scratchCard;
    [SerializeField] private EraseProgress eraseProgress;
    [SerializeField, Range(0, 1)] private float threshold;

    [SerializeField] private ScratchMode scratchMode;
    [SerializeField] private UnityEvent OnAutoFillCompleted;

    void Awake()
    {
        scratchMode = scratchCard.Mode;
        eraseProgress.OnProgress += ProcessEraseProgress;

    }
    void OnDisable()
    {
        eraseProgress.OnProgress -= ProcessEraseProgress;

    }

    private void ProcessEraseProgress(float progress)
    {
        if (scratchMode == ScratchMode.Erase)
        {
            if (progress >= threshold)
            {
                scratchCard.FillInstantly();
                OnAutoFillCompleted?.Invoke();
            }
        }
        else
        {
            if (progress < threshold)
            {
                scratchCard.ClearInstantly();
                OnAutoFillCompleted?.Invoke();
            }
        }
    }
}
