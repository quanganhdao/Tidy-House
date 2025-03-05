using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DialogAppearAction : DotweenAnimationAction
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void DoAction()
    {
        if (!DOTween.IsTweening(transform))
        {
            Appear();
        }
        base.DoAction();
    }
    public void Appear()
    {
        Debug.Log("Appear");
        transform.localScale = new Vector3(0.2f, 0.2f, 1);
        gameObject.SetActive(true);
        DOTween.Kill(transform);
        tween = transform.DOScale(1f, duration);
        // var rotateTween = transform.DORotate(Vector3.zero, duration).From(new Vector3(0, 0, -45));

    }
}
