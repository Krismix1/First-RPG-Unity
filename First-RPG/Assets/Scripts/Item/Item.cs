﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item"; // All objects have a field "name", so we use "new" keyword to hide it
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use() {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory() {
        Inventory.instance.RemoveItem(this);
    }
}
