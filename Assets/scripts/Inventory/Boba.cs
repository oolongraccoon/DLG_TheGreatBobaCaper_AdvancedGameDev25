using UnityEngine;
using System;

public class Boba : MonoBehaviour, IItem
{

    public ItemData itemData;//boba data
    public static event Action<int> OnBobaCollect; // Event triggered when a Boba is collected

    public int worth = 1;
    public string pickupMonologue;
    private bool isCollected = false; //prevent multiple collections of the same item

    public ItemData Collect()
    {
        if (isCollected) return null;
        
        isCollected = true;// Mark this item as collected

        ItemData dataToReturn = itemData;//Store the item data to return later

        bool added = Inventory.instance.Add(itemData); //add to player's inventory
        if (!added)
        {
            Debug.Log("Inventory is full! Item not collected.");
            return null;
        }


        OnBobaCollect?.Invoke(worth);//Trigger the Boba collection event and send its worth


        // Show monologue
        if (!string.IsNullOrEmpty(pickupMonologue))
        {
            MonologueManager.instance.ShowMonologue(pickupMonologue);
        }


        Destroy(gameObject); // // object is safe to destroy AFTER data is saved

        return dataToReturn;
    }
}
