using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScratchCardAsset;
using UnityEngine;

public class ScratchCardChannel : SingletonBase<ScratchCardChannel>
{
    // Start is called before the first frame update
    public List<ScratchCard> ListCard { get; set; }

    private void Awake()
    {
    }

    public void DisableAllCard()
    {
        ListCard = FindObjectsOfType<ScratchCard>().ToList();
        foreach (var item in ListCard)
        {
            item.enabled = false;
        }
    }
}
