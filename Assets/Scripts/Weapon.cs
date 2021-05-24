using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Weapon : Item
{
    public override Type ItemType { get => typeof(Weapon); }
}
