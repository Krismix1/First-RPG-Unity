using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    private Inventory() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogWarning("Trying to create to many Inventory objects.");
        }
    }

    public static Inventory instance;
    #endregion

    public List<Item> items = new List<Item>();
    public int size = 20;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public bool AddItem(Item item) {
        if (!item.isDefaultItem) {
            if(items.Count < size) {
                items.Add(item);

                if (onItemChangedCallback != null) {
                    onItemChangedCallback.Invoke();
                }
            } else {
                Debug.Log("Not enough room in the inventory");
                return false;
            }
        }

        return true;
    }

    public void RemoveItem(Item item) {
        items.Remove(item);

        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }
}
