using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject // hold boba data
{
    public string itemName;
    public Sprite icon;
}
