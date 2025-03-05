using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOriginalPositionAction : ActionBase
{
    [SerializeField] private ItemBase target;
    [SerializeField] private Transform newOriginalPosition;
    public override void DoAction()
    {
        target.OriginalPosition = newOriginalPosition.position;
    }
}
