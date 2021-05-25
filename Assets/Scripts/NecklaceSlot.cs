using UnityEngine;
using System;

public class NecklaceSlot : Slot
{
    public override Type StoredType { get => typeof(Necklace); }
}
