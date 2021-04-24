using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    protected Item storedItem = null;

    private void Start()
    {
        Item item = GetComponentInChildren<Item>();
        storedItem = item;
        if(item != null) item.OccupiedSlot = this;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped in slot");
        GameObject droppedObj = eventData.pointerDrag;
        if(droppedObj != null)
        {
            Item droppedItem = droppedObj.GetComponent<Item>();
            if (droppedItem != null) HandleDrop(droppedItem);
        }
    }

    public virtual void HandleDrop(Item item) {}

    protected void PlaceItem(Item item)
    {
        if (storedItem == null)
        {
            storedItem = item;
            item.OccupiedSlot.storedItem = null;
            item.OccupiedSlot = this;

            RectTransform itemRectTransform = item.GetComponent<RectTransform>();
            itemRectTransform.SetParent(transform);
            itemRectTransform.anchoredPosition = Vector2.zero;
            item.DroppedSuccesfully = true;
        }
        else
        {
            item.ResetPosition();
        }
    }
}
