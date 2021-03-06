﻿using UnityEngine;

public class PickUpItem : Interactable {

    public Item item;

    public override void Interact() {
        PickUp();
    }

    void PickUp() {
        Debug.Log("Picking up " + item.name);

        bool wasPickedUp = Inventory.instance.AddItem(item);
        if (wasPickedUp) {
            Destroy(gameObject);
        }
    }
}
