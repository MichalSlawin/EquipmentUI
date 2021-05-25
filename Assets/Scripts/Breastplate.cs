using UnityEngine;
using System;

public class Breastplate : Armor
{
    public override Type ItemType { get => typeof(Breastplate); }

    public override string ToString()
    {
        return "Breastplate" + base.ToString();
    }
}
