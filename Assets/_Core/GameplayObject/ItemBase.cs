using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemBase : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDraggable = true;
    public UnityEvent OnDroppedRightPlace;

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
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        GameObject dropZone = eventData.pointerEnter;
        if (dropZone.TryGetComponent<DropDestination>(out var dropDestination))
        {
            var isValid = dropDestination.DoesNeedItem(this);
            if (isValid)
            {
                OnDroppedRightPlace?.Invoke();
            }
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
