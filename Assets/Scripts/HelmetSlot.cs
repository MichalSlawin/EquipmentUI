using UnityEngine;
using System;

public class HelmetSlot : Slot
{
    public override Type StoredType { get => typeof(Helmet); }

    public override void HandleDrop(Item item)
    {
        Helmet helmet = item.GetComponent<Helmet>();
        if (helmet != null)
        {
            SwapItems(helmet);
            gameController.StartShowCoroutine(helmet);
        }
        else
        {
            item.ResetPosition();
        }
    }
}
