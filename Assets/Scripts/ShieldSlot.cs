

public class ShieldSlot : Slot
{
   public override void HandleDrop(Item item)
   {
        Shield shield = item.GetComponent<Shield>();
        if (shield != null)
        {
            SwapItems(shield);
            gameController.StartShowCoroutine(shield);
        }
        else
        {
            item.ResetPosition();
        }
   }
}
