

public class SwordSlot : Slot
{
    public override void HandleDrop(Item item)
    {
        Sword sword = item.GetComponent<Sword>();
        if(sword != null)
        {
            SwapItems(sword);
            gameController.StartShowCoroutine(sword);
        }
        else
        {
            item.ResetPosition();
        }
    }
}
