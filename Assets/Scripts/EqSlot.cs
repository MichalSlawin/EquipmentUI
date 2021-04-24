using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqSlot : Slot
{
    public override void HandleDrop(Item item)
    {
        Debug.Log("Dropped in eq");
        PlaceItem(item);
    }
}
