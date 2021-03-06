﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item {
    public int armourModifier;
    public int damageModifier;
    public EquipmentSlot equipmentSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public override void Use() {
        base.Use();

        // Equip item
        EquipmentManager.instance.Equip(this);
        // Remove from inventory
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {
    Head, Chest, Legs, Weapon, Shield, Feet
}

public enum EquipmentMeshRegion { // corresponds to body blendshapes
    Legs, Arms, Torso
}
