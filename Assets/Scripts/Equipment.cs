using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private const int SLOTS_NUM = 12;

    [SerializeField] private EqSlot[] equipmentSlots;
    [SerializeField] private NecklaceSlot necklaceSlot;
    [SerializeField] private HelmetSlot helmetSlot;
    [SerializeField] private RingSlot ringSlot;
    [SerializeField] private WeaponSlot weaponSlot;
    [SerializeField] private BreastplateSlot breastplateSlot;
    [SerializeField] private ShieldSlot shieldSlot;
    [SerializeField] private PantsSlot pantsSlot;
    [SerializeField] private BootsSlot bootsSlot;
    [SerializeField] private GlovesSlot glovesSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
