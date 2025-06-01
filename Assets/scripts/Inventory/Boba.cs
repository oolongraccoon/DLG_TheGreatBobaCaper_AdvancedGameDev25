using UnityEngine;
using System;

public class Boba : MonoBehaviour, IItem
{
    public ItemData itemData;
    public static event Action<int> OnBobaCollect;
    public int worth = 1;
    public string pickupMonologue;
    private bool isCollected = false;

    public ItemData Collect()
    {
        if (isCollected) return null;
        isCollected = true;

        ItemData dataToReturn = itemData;

        bool added = Inventory.instance.Add(itemData);
        if (!added)
        {
            Debug.Log("Inventory is full! Item not collected.");
            return null;
        }

        OnBobaCollect?.Invoke(worth);

        // Show monologue
        if (!string.IsNullOrEmpty(pickupMonologue))
        {
            MonologueManager.instance.ShowMonologue(pickupMonologue);
        }

        Destroy(gameObject); // ✅ Ensure the item is destroyed
        return dataToReturn;
    }
}
