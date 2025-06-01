// GameEventsManager.cs
using UnityEngine;
using System; // Required for Action events

public class GameEventsManager : MonoBehaviour
{
    // Static instance of the GameEventsManager (Singleton pattern)
    // This allows other scripts to access it like: GameEventsManager.instance
    public static GameEventsManager instance { get; private set; }

    // This is the property that will hold your DialogueEvents
    // You need to initialize it in Awake() or Start()
    public DialogueEvents dialogueEvents;

    private void Awake()
    {
        // Singleton enforcement: Ensure only one instance of this manager exists
        if (instance != null && instance != this)
        {
            // If another instance already exists, destroy this one
            Destroy(gameObject);
            Debug.LogWarning("Duplicate GameEventsManager found. Destroying this one.");
        }
        else
        {
            // Set this instance as the singleton instance
            instance = this;
            // Optional: If this manager should persist across scene loads
            // DontDestroyOnLoad(gameObject);
        }

        // Initialize your DialogueEvents here
        // This creates an instance of the DialogueEvents class
        dialogueEvents = new DialogueEvents();

        Debug.Log("GameEventsManager initialized.");
    }

    // --- You can add other sub-managers here if needed, e.g.,
    // public PlayerEvents playerEvents;
    // public UIEvents uiEvents;
    // private void Awake() { /* ... initialize playerEvents = new PlayerEvents(); etc. */ }
}

// DialogueEvents.cs (You can put this in a separate file, or keep it below GameEventsManager for now)
// Note: This class does NOT inherit from MonoBehaviour, it's a plain C# class.
public class DialogueEvents
{
    // This is the event that your DialogueChoiceButton will trigger.
    // 'Action<int>' means it's an event that takes one integer argument.
    public event Action<int> OnChoiceIndexSelected; // Renamed for clarity

    // This is the method that DialogueChoiceButton will call.
    public void UpdateChoiceIndex(int newChoiceIndex)
    {
        Debug.Log("Dialogue Choice Index Updated: " + newChoiceIndex);
        // Invoke the event, notifying any listeners
        OnChoiceIndexSelected?.Invoke(newChoiceIndex);
    }
}