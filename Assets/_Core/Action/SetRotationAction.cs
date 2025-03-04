using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotationAction : ActionBase
{
    [SerializeField]
    private Vector3 rotation
    ;
    [SerializeField] private Transform target;
    public override void DoAction()
    {
        target.rotation = Quaternion.Euler(rotation);
    }
}
