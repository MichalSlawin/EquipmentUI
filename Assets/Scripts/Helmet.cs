using UnityEngine;
using System;

public class Helmet : Armor
{
    public override Type ItemType { get => typeof(Helmet); }

    public override string ToString()
    {
        return "Helmet" + base.ToString();
    }
}
