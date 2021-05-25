using System;

public class WeaponSlot : Slot
{
    public override Type StoredType { get => typeof(Weapon); }
}
