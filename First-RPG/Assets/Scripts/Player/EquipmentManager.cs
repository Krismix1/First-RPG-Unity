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

    public SkinnedMeshRenderer targetMesh;
    public Equipment[] defaultItems;

    Equipment[] currentEquipment;
    Inventory inventory;
    SkinnedMeshRenderer[] currentMeshes;

    private void Start() {
        int numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numOfSlots];
        inventory = Inventory.instance;
        currentMeshes = new SkinnedMeshRenderer[numOfSlots];

        EquipDefaultItems();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }

    public void Equip(Equipment newItem) {
        int slotIndex = (int)newItem.equipmentSlot;

        Equipment oldItem = Unequip(slotIndex);

        currentEquipment[slotIndex] = newItem;

        if(onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        SetEquipmentBlendShape(newItem, 100);

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slot) {
        Equipment oldItem = currentEquipment[slot];
        if(oldItem != null) {
            inventory.AddItem(oldItem);
            currentEquipment[slot] = null;

            if(currentMeshes[slot] != null) {
                Destroy(currentMeshes[slot].gameObject);
            }

            SetEquipmentBlendShape(oldItem, 0);

            if (onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
        return oldItem;
    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length; i++) {
            Unequip(i);
        }
        EquipDefaultItems();
    }

    public void SetEquipmentBlendShape(Equipment item, int weight) {
        foreach (EquipmentMeshRegion region in item.coveredMeshRegions) {
            targetMesh.SetBlendShapeWeight((int)region, weight);
        }
    }

    void EquipDefaultItems() {
        foreach(Equipment item in defaultItems){
            Equip(item);
        }
    }
}
