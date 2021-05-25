using UnityEngine;
using System;

public class HelmetSlot : Slot
{
    public override Type StoredType { get => typeof(Helmet); }
}
