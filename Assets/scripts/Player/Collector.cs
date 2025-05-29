using UnityEngine;

public class Collector : MonoBehaviour
{
    public Inventory inventory; // Make this public so you can assign it in the Inspector

    private void Start()
    {
        if (inventory == null)
        {
            // Corrected line 11: Using FindFirstObjectByType instead of FindObjectOfType
            inventory = GameObject.FindFirstObjectByType<Inventory>(); // Find the Inventory if it's not assigned
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision?.GetComponent<IItem>();
        Debug.Log("?");
        if (item != null)
        {
            // You might want to consider if setting isTrigger to false is always desired here.
            // If the item is supposed to be "collected" and disappear, you might destroy it instead.
            // If it's a permanent fixture that changes state, then setting isTrigger to false could make sense.
            collision.isTrigger = false;

            ItemData data = item.Collect();
            if (data != null)
            {
                inventory.Add(data);
            }
        }
    }
}