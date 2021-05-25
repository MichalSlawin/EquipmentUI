using UnityEngine;
using System;

public class Shield : Armor
{
    public override Type ItemType { get => typeof(Shield); }

    public override string ToString()
    {
        return "Shield" + base.ToString();
    }
}
