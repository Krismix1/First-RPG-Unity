using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;
    InventorySlot[] inventorySlots;


	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	

	void Update () {
        if (Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI() {
        for (int i = 0; i < inventorySlots.Length; i++) {
            if(i < inventory.items.Count) {
                inventorySlots[i].AddItem(inventory.items[i]);
            } else {
                inventorySlots[i].ClearSlot();
            }
        }
    }
}
