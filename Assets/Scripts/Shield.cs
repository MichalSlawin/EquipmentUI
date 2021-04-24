using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    [SerializeField] private float defence = 5f;

    public float Defence { get => defence; set => defence = value; }

    public override string ToString()
    {
        return "Shield (Defence: " + defence.ToString() + ")";
    }
}
