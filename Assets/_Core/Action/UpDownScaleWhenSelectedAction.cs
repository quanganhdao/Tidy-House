using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpDownScaleWhenSelectedAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private Vector3 clickScale = new Vector3(0.9f, 0.9f, 0.9f);
    [SerializeField] private Vector3 defaultScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private bool isScale = true;
    [SerializeField] private float duration = 0.09f;


    public void OnPointerUp(PointerEventData eventData)
    {
        if (isScale)
        {
            transform.DOScale(defaultScale, duration);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (isScale)
        {
            transform.DOScale(hoverScale, duration);
        }
    }
}
