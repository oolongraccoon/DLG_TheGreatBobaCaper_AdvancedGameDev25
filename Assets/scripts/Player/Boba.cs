
using UnityEngine;

public class Boba : MonoBehaviour, IItem
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
