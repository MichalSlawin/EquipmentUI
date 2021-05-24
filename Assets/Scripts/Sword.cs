using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private float attackDamage = 5f;

    public float AttackDamage { get => attackDamage; set => attackDamage = value; }

    public override string ToString()
    {
        return "Sword (Attack: " + attackDamage.ToString() + ")";
    }
}
