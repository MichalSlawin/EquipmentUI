using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Equipment equipment = null;
    [SerializeField] private GameController gameController = null;

    private float defence = 0;
    private float attack = 0;

    public float Defence { get => defence; set => defence = value; }
    public float Attack { get => attack; set => attack = value; }

    private void Start()
    {
        equipment.SlotChanged += HandleSlotChange;
    }

    public void HandleSlotChange(object sender, EventArgs eventArgs)
    {
        UpdateStats();
    }

    private void UpdateStats()
    {
        attack = equipment.GetAttackSum();
        defence = equipment.GetDefenceSum();
        gameController.UpdateStatsText(attack, defence);
    }
}
