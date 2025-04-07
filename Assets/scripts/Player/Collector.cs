using UnityEngine;

public class Collector : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();
        if (item != null)
        {
            ItemData data = item.Collect();
            if (data != null)
            {
                inventory.AddItem(data);
            }
        }
    }
}
