using UnityEngine;
using System;

public class Boba : MonoBehaviour, IItem
{
<<<<<<< HEAD
    public ItemData itemData;
    public static event Action<int> OnBobaCollect;
    public int worth = 1;
    public string pickupMonologue;
    private bool isCollected = false;
=======
    public ItemData itemData;//boba data
    public static event Action<int> OnBobaCollect; // Event triggered when a Boba is collected
    public int worth = 1;
    public string pickupMonologue;
    private bool isCollected = false; //prevent multiple collections of the same item
>>>>>>> origin/bugfix

    public ItemData Collect()
    {
        if (isCollected) return null;
<<<<<<< HEAD
        isCollected = true;

        ItemData dataToReturn = itemData;
=======
        isCollected = true;// Mark this item as collected

        ItemData dataToReturn = itemData;//Store the item data to return later
>>>>>>> origin/bugfix

        bool added = Inventory.instance.Add(itemData); //add to player's inventory
        if (!added)
        {
            Debug.Log("Inventory is full! Item not collected.");
            return null;
        }

<<<<<<< HEAD
        OnBobaCollect?.Invoke(worth);
=======
        OnBobaCollect?.Invoke(worth);//Trigger the Boba collection event and send its worth
>>>>>>> origin/bugfix

        // Show monologue
        if (!string.IsNullOrEmpty(pickupMonologue))
        {
            MonologueManager.instance.ShowMonologue(pickupMonologue);
        }

<<<<<<< HEAD
        Destroy(gameObject); // ✅ Ensure the item is destroyed
=======
        Destroy(gameObject); // // object is safe to destroy AFTER data is saved

>>>>>>> origin/bugfix
        return dataToReturn;
    }
}
