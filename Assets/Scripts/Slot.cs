using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped item");
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
        RectTransform itemRectTransform = item.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
