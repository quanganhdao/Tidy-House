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
    private Vector3 originalRotation;

    private Vector2 offset;

    private Transform originalParent;
    private int indexInParent;

    private Canvas canvas;
    void Awake()
    {
        originalParent = transform.parent;
        indexInParent = transform.GetSiblingIndex();

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
        canvas = FindObjectOfType<Canvas>();
    }


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = canvas.transform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)rectTransform.parent,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );
        offset -= rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        if (!isDraggable) return;
        OnPickedUp?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)rectTransform.parent,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
        {
            rectTransform.anchoredPosition = localPoint - offset;
        }
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
        canvasGroup.blocksRaycasts = true;
    }

    private void DropWrong()
    {
        if (isResetPositionWhenPlaceWrong)
        {
            transform.parent = originalParent;
            transform.SetSiblingIndex(indexInParent);
            transform.localPosition = originalPosition;
        }
        OnDropWrongPlace?.Invoke();
    }

    public void SetIsDraggable(bool drag)
    {
        isDraggable = drag;
    }

}
