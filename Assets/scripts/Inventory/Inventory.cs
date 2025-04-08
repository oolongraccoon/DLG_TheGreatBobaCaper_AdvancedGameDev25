using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();

    public void AddItem(ItemData item)
    {
        if (item == null) return;

        // Check if item already exists in inventory (by comparing ItemData objects)
        if (items.Contains(item))
        {
            Debug.Log("Item already exists in inventory: " + item.itemName);
            return; // or handle increasing quantity if applicable
        }

        items.Add(item);
        Debug.Log("Added item: " + item.itemName);

    }
}
