using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CrossOverTrigger : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private List<ItemBase> itemsCanCross;
    [SerializeField] private UnityEvent OnRightItemEntered;

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.TryGetComponent<ItemBase>(out var itemBase))
    //     {
    //         if (itemsCanCross.Contains(itemBase))
    //         {

    //             OnRightItemEntered?.Invoke();
    //         }
    //     }
    // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<ItemBase>(out var itemBase))
        {
            if (itemsCanCross.Contains(itemBase))
            {
                OnRightItemEntered?.Invoke();
                Debug.Log("Right Item Entered");
            }
        }
    }
}
