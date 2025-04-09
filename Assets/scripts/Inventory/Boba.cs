using UnityEngine;

public class Boba : MonoBehaviour, IItem
{
    public ItemData itemData;

    public ItemData Collect()
    {
        ItemData dataToReturn = itemData;
        Destroy(gameObject); // object is safe to destroy AFTER data is saved
        return dataToReturn;
    }
}
