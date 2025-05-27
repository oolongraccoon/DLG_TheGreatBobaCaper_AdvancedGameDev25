using UnityEngine;
using System;

public class Boba : MonoBehaviour, IItem
{
    public ItemData itemData;
    public static event Action<int> OnBobaCollect;
    public int worth = 1;

    public ItemData Collect()
    {
        ItemData dataToReturn = itemData;

        bool added = Inventory.instance.Add(itemData);
        if (!added)
        {
            Debug.Log("Inventory is full! Item not collected.");
            return null;
        }

        OnBobaCollect?.Invoke(worth);
        Destroy(gameObject); // object is safe to destroy AFTER data is saved
        return dataToReturn;
    }
}
