﻿public class PlayerStats : CharacterStats {

    private void Start() {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    private void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
        if(newItem != null) {
            armour.AddModifier(newItem.armourModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if(oldItem != null) {
            armour.RemoveModifier(oldItem.armourModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die() {
        base.Die();

        PlayerManager.instance.KillPlayer();
    }
}
