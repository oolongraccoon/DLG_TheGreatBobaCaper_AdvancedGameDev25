using UnityEngine;
using System;

public class Boba : MonoBehaviour, IItem
{
    public ItemData itemData;
    public static event Action<int> OnBobaCollect; // Event triggered when a Boba is collected
    public int worth = 1;
    private bool isCollected = false; // Prevent double collection


    public ItemData Collect()
    {
        if (isCollected) return null; 
        isCollected = true; // Mark this item as collected

        ItemData dataToReturn = itemData; // Store the item data to return later

        bool added = Inventory.instance.Add(itemData);
        if (!added)
        {
            Debug.Log("Inventory is full! Item not collected.");
            return null;
        }

        OnBobaCollect?.Invoke(worth); // Trigger the Boba collection event and send its worth
        Destroy(gameObject); // object is safe to destroy AFTER data is saved
        return dataToReturn;
    }
}
