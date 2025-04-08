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

    // Callback which is triggered when
    // an item gets added/removed.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;  // Amount of slots in inventory

    // Current list of items in inventory
    public List<IItem> items = new List<IItem>();

    // Add a new item. If there is enough room we
    // return true. Else we return false.
    public bool Add(IItem item)
    {
        items.Add(item);    // Add item to list
        Debug.Log("Added item: " + item.itemName);
        // Trigger callback
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
