using System;

public class WeaponSlot : Slot
{
    public override Type StoredType { get => typeof(Weapon); }

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
