using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Equipment : MonoBehaviour
{
    public event EventHandler SlotChanged;

    [SerializeField] private EqSlot[] equipmentSlots;

    [SerializeField] private WeaponSlot weaponSlot = null;

    [SerializeField] private NecklaceSlot necklaceSlot = null;
    [SerializeField] private HelmetSlot helmetSlot = null;
    [SerializeField] private RingSlot ringSlot = null;
    [SerializeField] private BreastplateSlot breastplateSlot = null;
    [SerializeField] private ShieldSlot shieldSlot = null;
    [SerializeField] private PantsSlot pantsSlot = null;
    [SerializeField] private BootsSlot bootsSlot = null;
    [SerializeField] private GlovesSlot glovesSlot = null;

    private void Start()
    {
        necklaceSlot.SlotChanged += HandleSlotChange;
        helmetSlot.SlotChanged += HandleSlotChange;
        ringSlot.SlotChanged += HandleSlotChange;
        weaponSlot.SlotChanged += HandleSlotChange;
        breastplateSlot.SlotChanged += HandleSlotChange;
        shieldSlot.SlotChanged += HandleSlotChange;
        pantsSlot.SlotChanged += HandleSlotChange;
        bootsSlot.SlotChanged += HandleSlotChange;
        glovesSlot.SlotChanged += HandleSlotChange;
    }

    public void HandleSlotChange(object sender, EventArgs eventArgs)
    {
        OnSlotChanged(EventArgs.Empty);
    }

    protected virtual void OnSlotChanged(EventArgs eventArgs)
    {
        if (SlotChanged != null) SlotChanged.Invoke(this, eventArgs);
    }

    public float GetAttackSum()
    {
        float sum = 0;

        if(weaponSlot.StoredItem != null) sum += ((Weapon)weaponSlot.StoredItem).AttackDamage;

        return sum;
    }

    public float GetDefenceSum()
    {
        float sum = 0;

        if (necklaceSlot.StoredItem != null) sum += ((Armor)necklaceSlot.StoredItem).Defence;
        if (helmetSlot.StoredItem != null) sum += ((Armor)helmetSlot.StoredItem).Defence;
        if (ringSlot.StoredItem != null) sum += ((Armor)ringSlot.StoredItem).Defence;
        if (breastplateSlot.StoredItem != null) sum += ((Armor)breastplateSlot.StoredItem).Defence;
        if (shieldSlot.StoredItem != null) sum += ((Armor)shieldSlot.StoredItem).Defence;
        if (pantsSlot.StoredItem != null) sum += ((Armor)pantsSlot.StoredItem).Defence;
        if (bootsSlot.StoredItem != null) sum += ((Armor)bootsSlot.StoredItem).Defence;
        if (glovesSlot.StoredItem != null) sum += ((Armor)glovesSlot.StoredItem).Defence;

        return sum;
    }
}
