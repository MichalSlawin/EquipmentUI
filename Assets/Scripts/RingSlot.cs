using UnityEngine;
using System;

public class RingSlot : Slot
{
    public override Type StoredType { get => typeof(Ring); }
}
