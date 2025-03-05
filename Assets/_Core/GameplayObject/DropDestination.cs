using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropDestination : MonoBehaviour
{
    [SerializeField] private Transform snapPosition;
    [SerializeField] private ItemBase necessaryItem;
    public Transform GetSnapPosition()
    {
        return snapPosition;
    }
    public bool DoesNeedItem(ItemBase item)
    {
        return item == necessaryItem;
    }

    public void PlaceItem()
    {
        necessaryItem.transform.DOMove(snapPosition.position, 0.1f);
    }
}
