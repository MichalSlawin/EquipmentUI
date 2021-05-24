using UnityEngine;
using System;

public class Shield : Item
{
    [SerializeField] private float defence = 5f;

    public float Defence { get => defence; set => defence = value; }

    public override Type ItemType { get => typeof(Shield); }

    public override string ToString()
    {
        return "Shield (Defence: " + defence.ToString() + ")";
    }
}
