using System;
using UnityEngine;

public abstract class Armor : Item
{
    [SerializeField] private float defence = 5f;

    public float Defence { get => defence; set => defence = value; }

    public override Type ItemType { get => typeof(Armor); }

    public override string ToString()
    {
        return ItemType.ToString() + " (Defence: " + Defence.ToString() + ")";
    }
}
