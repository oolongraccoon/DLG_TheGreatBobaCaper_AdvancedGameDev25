using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object between scenes
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }
}
