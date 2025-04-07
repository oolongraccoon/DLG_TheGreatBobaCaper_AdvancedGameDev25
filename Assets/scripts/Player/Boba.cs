
using UnityEngine;

public class Boba : MonoBehaviour, IItem
{
    public ItemData itemData;

    public ItemData Collect()
    {
        Destroy(gameObject);
        return itemData;
    }
}
