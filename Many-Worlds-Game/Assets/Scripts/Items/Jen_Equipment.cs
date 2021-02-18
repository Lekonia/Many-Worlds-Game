using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Jen_Equipment : Jen_Item
{
    public string tagName;
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;


    public int armourModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        Jen_EquipmentManager.instance.Equip(this, tagName);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion { Legs, Arms, Torso }; //Corresponds to body blendshapes.