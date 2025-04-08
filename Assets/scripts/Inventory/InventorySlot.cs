using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

    public Image icon;          // Reference to the Icon image

    IItem item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(IItem newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

}
