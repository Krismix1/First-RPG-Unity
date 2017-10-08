using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Equipment[] currentEquipment;
    Inventory inventory;

    private void Start() {
        int numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numOfSlots];
        inventory = Inventory.instance;
    }

    public void Equip(Equipment newItem) {
        int slotIndex = (int)newItem.equipmentSlot;

        Equipment oldItem = currentEquipment[slotIndex];

        if (oldItem != null) {
            inventory.AddItem(oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        if(onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
    }

    public void UnEquip(int slot) {
        Equipment oldItem = currentEquipment[slot];
        if(oldItem != null) {
            inventory.AddItem(oldItem);

            if (onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }
}
