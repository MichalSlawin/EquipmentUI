using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlot : Slot
{
    public override void HandleDrop(Item item)
    {
        Sword sword = item.GetComponent<Sword>();
        if(sword != null)
        {
            PlaceItem(sword);
        }
        else
        {
            item.ResetPosition();
        }
    }
}
