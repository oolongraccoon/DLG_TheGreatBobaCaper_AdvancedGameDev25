using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion
    // Callback when an item gets added/removed

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 6;  // Amount of slots

    // List to store the current items held by the inventory.
    public List<ItemData> items = new List<ItemData>();

    public bool Add(ItemData item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        items.Add(item);    // Add item

        // Trigger callback
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;  // Return true when item is successfully added
    }

}
