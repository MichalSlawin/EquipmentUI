using System;

public class EqSlot : Slot
{
    public override Type StoredType { get => typeof(Item); }

    public override void HandleDrop(Item item)
    {
        SwapItems(item);
    }
}
