using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonIdleScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DoAction();
    }

    private void DoAction()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(Vector3.one * 0.9f, 0.7f));
        // seq.Append(transform.DOScale(Vector3.one * 1.1f, 0.4f));
        // seq.Append(transform.DOScale(Vector3.one, 0.3f));
        seq.SetLoops(-1, LoopType.Yoyo);
    }
}
