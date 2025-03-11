using System.Collections;
using System.Collections.Generic;
using ScratchCardAsset;
using UnityEngine;

public class SetTargetToScratchAction : ActionBase
{
    [SerializeField] private List<ScratchCard> scratchCardsAffectable;
    [SerializeField] private Transform scratchPoint;

    public override void DoAction()
    {
        foreach (var item in scratchCardsAffectable)
        {
            item.SetScratchPoint(scratchPoint);
            item.UseMousePositionToScratch = false;
        }
    }

    public void UndoAction()
    {
        foreach (var item in scratchCardsAffectable)
        {
            item.ScratchPoint = null;
            item.UseMousePositionToScratch = true;
        }
    }
}
