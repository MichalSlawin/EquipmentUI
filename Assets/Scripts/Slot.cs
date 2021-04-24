﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    protected Item storedItem = null;
    protected GameController gameController = null;

    private void Start()
    {
        Item item = GetComponentInChildren<Item>();
        storedItem = item;
        if(item != null) item.OccupiedSlot = this;

        gameController = FindObjectOfType<GameController>();
        if (gameController == null) throw new System.Exception("Game Controller not found");
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObj = eventData.pointerDrag;
        if(droppedObj != null)
        {
            Item droppedItem = droppedObj.GetComponent<Item>();
            if (droppedItem != null) HandleDrop(droppedItem);
        }
    }

    public virtual void HandleDrop(Item item) {}

    private void PlaceItem(Item item)
    {
        storedItem = item;
        item.OccupiedSlot = this;

        RectTransform itemRectTransform = item.GetComponent<RectTransform>();
        itemRectTransform.SetParent(transform);
        itemRectTransform.anchoredPosition = Vector2.zero;
    }

    protected void SwapItems(Item item)
    {
        Item tempItem = storedItem;
        Slot tempSlot = item.OccupiedSlot;
        
        if(tempItem == null)
        {
            item.OccupiedSlot.storedItem = null;
        }

        PlaceItem(item);
        
        if (tempItem != null)
        {
            tempSlot.PlaceItem(tempItem);
        }

        item.DroppedSuccesfully = true;
    }
}
