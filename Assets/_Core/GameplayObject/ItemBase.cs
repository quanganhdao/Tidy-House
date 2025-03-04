using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using JetBrains.Annotations;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDraggable = true;
    [SerializeField] private bool isDroppable = true;
    [SerializeField] private bool isResetPositionWhenPlaceWrong = true;
    [SerializeField] private bool isSetPosToDestinationWhenPlaceRight;
    [SerializeField] private UnityEvent OnPickedUp;
    public UnityEvent OnDroppedRightPlace;
    [SerializeField] private UnityEvent OnDropWrongPlace;

    [SerializeField] private CanvasGroup canvasGroup;

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    void Awake()
    {
        if (canvasGroup == null)
        {
            if (TryGetComponent<CanvasGroup>(out var canvasGroup))
            {
                this.canvasGroup = canvasGroup;
            }
            else
            {
                this.canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
    }


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
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
        canvasGroup.blocksRaycasts = true;
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
                if (isSetPosToDestinationWhenPlaceRight)
                {
                    dropDestination.PlaceItem();
                }
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

    public void SetIsDraggable(bool drag)
    {
        isDraggable = drag;
    }

}
