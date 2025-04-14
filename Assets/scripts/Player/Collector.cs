using UnityEngine;

public class Collector : MonoBehaviour
{
    public Inventory inventory;  // Make this public so you can assign it in the Inspector

    private void Start()
    {
        if (inventory == null)
        {
            inventory = GameObject.FindObjectOfType<Inventory>();  // Find the Inventory if it's not assigned
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision?.GetComponent<IItem>();
        Debug.Log("?");
        if (item != null)
        {
            collision.isTrigger = false;
            ItemData data = item.Collect();
            if (data != null)
            {
                inventory.Add(data);
            }
        }
    }
}
