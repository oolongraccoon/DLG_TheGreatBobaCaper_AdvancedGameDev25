using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;
    public GameObject player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object between scenes

            // Subscribe to scene load event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    // This method is called every time a new scene loads
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Destroy this object if the scene is GameStartMenu
        if (scene.name == "GameStartMenu")
        {
            Destroy(gameObject);
        }
        if (scene.name == "SecondScene")
        {
            player = GameObject.FindWithTag("Player"); // Assuming your player GameObject has the tag "Player"
            if (player != null)
            {
                player.transform.position = new Vector3(-3f, 12f, 0f);//a fixed position in second scene
            }
        }
    }


    void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
