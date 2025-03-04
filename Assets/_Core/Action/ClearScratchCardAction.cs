using System;
using System.Collections;
using System.Collections.Generic;
using ScratchCardAsset;
using UnityEngine;

[RequireComponent(typeof(ScratchCard))]
public class ClearScratchCardAction : ActionBase
{
    [SerializeField] private bool clearOnAwake = false;
    private ScratchCard scratchCard;
    void Awake()
    {
        scratchCard = GetComponent<ScratchCard>();

    }
    public override void DoAction()
    {
        // GetComponent<ScratchCard>().ClearInstantly();
        StartCoroutine(WaitScratchCardInit(() =>
    {
        scratchCard.FillInstantly();

    }));
    }

    private IEnumerator WaitScratchCardInit(Action onInit)
    {
        Debug.Log(scratchCard);
        while (!scratchCard.IsScratchCardRendererInit())
        {
            yield return null;
        }
        onInit?.Invoke();
    }
    void OnEnable()
    {
        if (clearOnAwake)
        {
            DoAction();
        }
    }
}
