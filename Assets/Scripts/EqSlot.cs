

public class EqSlot : Slot
{
    public override void HandleDrop(Item item)
    {
        SwapItems(item);
    }
}
