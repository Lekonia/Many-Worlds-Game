using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jen_EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static Jen_EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    Jen_Equipment[] currentEquipment;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Jen_Equipment[numSlots];
    }

    public void Equip (Jen_Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        currentEquipment[slotIndex] = newItem;
    }

}
