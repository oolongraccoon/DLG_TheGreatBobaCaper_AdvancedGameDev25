using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    public string monologueToDisplay; // The specific monologue for this trigger
    public MonologueManager monologueManager; // Reference to your MonologueManager
    public bool triggerOnce = true; // Should this trigger only happen once?

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider is the player AND if it hasn't triggered yet (if triggerOnce is true)
        if (other.CompareTag("Player") && (!triggerOnce || !hasTriggered))
        {
            if (monologueManager != null)
            {
                monologueManager.ShowMonologue(monologueToDisplay);
                hasTriggered = true; // Mark as triggered
            }
            else
            {
                Debug.LogError("MonologueManager not assigned to MonologueTrigger on " + gameObject.name);
            }
        }
    }
}