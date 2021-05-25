using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public abstract class Slot : MonoBehaviour, IDropHandler
{
    private Type storedType;

    protected Item storedItem = null;
    protected GameController gameController = null;
    private Color originalColor;

    public Color OriginalColor { get => originalColor; set => originalColor = value; }

    public abstract Type StoredType { get; }

    private void Start()
    {
        Item item = GetComponentInChildren<Item>();
        storedItem = item;
        if(item != null) item.OccupiedSlot = this;

        gameController = FindObjectOfType<GameController>();
        if (gameController == null) throw new System.Exception("Game Controller not found");

        OriginalColor = GetComponent<Image>().color;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObj = eventData.pointerDrag;
        if(droppedObj != null)
        {
            Item droppedItem = droppedObj.GetComponent<Item>();
            if (droppedItem != null && droppedItem.OccupiedSlot != this) HandleDrop(droppedItem);
        }
    }

    public virtual void HandleDrop(Item item)
    {
        if (item.ItemType == StoredType)
        {
            SwapItems(item);
            gameController.StartShowCoroutine(item);
        }
        else
        {
            item.ResetPosition();
        }
    }

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
        if (storedItem != null && storedItem.ItemType != item.OccupiedSlot.StoredType && !(item.OccupiedSlot is EqSlot))
        {
            item.ResetPosition();
            return;
        }

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

            if (tempSlot is WeaponSlot || tempSlot is ShieldSlot)
            {
                gameController.StartShowCoroutine(tempItem);
            }
        }

        item.DroppedSuccesfully = true;
    }
}
