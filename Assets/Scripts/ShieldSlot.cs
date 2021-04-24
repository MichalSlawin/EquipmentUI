using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSlot : Slot
{
   public override void HandleDrop(Item item)
   {
        Shield shield = item.GetComponent<Shield>();
        if (shield != null)
        {
            PlaceItem(shield);
        }
        else
        {
            item.ResetPosition();
        }
   }
}
