using System;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] private float attackDamage = 5f;

    public float AttackDamage { get => attackDamage; set => attackDamage = value; }

    public override Type ItemType { get => typeof(Weapon); }

    public override string ToString()
    {
        return " (Attack: " + AttackDamage.ToString() + ")";
    }
}
