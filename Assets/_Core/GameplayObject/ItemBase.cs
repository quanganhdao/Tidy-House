using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using JetBrains.Annotations;

public class ItemBase : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDraggable = true;
    [SerializeField] private bool isDroppable = true;
    [SerializeField] private bool isResetPositionWhenPlaceWrong = true;
    [SerializeField] private UnityEvent OnPickedUp;
    public UnityEvent OnDroppedRightPlace;
    [SerializeField] private UnityEvent OnDropWrongPlace;

    private RectTransform rectTransform;
    private Vector3 originalPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        OnPickedUp?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDroppable)
        {
            DropWrong();

            return;
        }

        if (!isDraggable) return;

        GameObject dropZone = eventData.pointerEnter;
        if (dropZone != null && dropZone.TryGetComponent<DropDestination>(out var dropDestination))
        {
            var isValid = dropDestination.DoesNeedItem(this);
            if (isValid)
            {
                OnDroppedRightPlace?.Invoke();
            }
        }
        else
        {
            DropWrong();
        }
    }

    private void DropWrong()
    {
        if (isResetPositionWhenPlaceWrong)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
        OnDropWrongPlace?.Invoke();
    }
}
