using System.Collections;
using System.Collections.Generic;
using ScratchCardAsset;
using UnityEngine;
using static ScratchCardAsset.ScratchCard;

public class ApplyLayerToBrushAction : ActionBase
{
    [SerializeField] private List<ScratchCard> scratchCardsAffectable;
    [SerializeField] private ScratchMode mode = ScratchMode.Restore;
    [SerializeField] private Transform scratchPoint;
    public override void DoAction()
    {
        var allcard = ScratchCardChannel.Instance.ListCard;
        for (int i = 0; i < allcard.Count; i++)
        {
            var isActive = scratchCardsAffectable.Contains(allcard[i]);
            if (isActive)
            {
                allcard[i].InputEnabled = isActive;
                allcard[i].SetScratchPoint(scratchPoint);
                allcard[i].Mode = mode;
            }
            allcard[i].enabled = isActive;

        }
    }

    public void DisableCards()
    {
        for (int i = 0; i < scratchCardsAffectable.Count; i++)
        {
            scratchCardsAffectable[i].enabled = false;
            scratchCardsAffectable[i].InputEnabled = false;

        }
    }
}
