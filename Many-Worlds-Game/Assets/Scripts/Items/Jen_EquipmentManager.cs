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

    public delegate void OnEquipmentChanged(Jen_Equipment newItem, Jen_Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Jen_Inventory inventory;

    void Start()
    {
        inventory = Jen_Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Jen_Equipment[numSlots];
    }

    public void Equip (Jen_Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Jen_Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Jen_Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i <currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }

}
