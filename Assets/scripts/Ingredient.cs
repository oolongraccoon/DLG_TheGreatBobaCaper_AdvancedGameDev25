using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public MonologueManager monologueManager; // Reference to the manager
    public string correctMonologue;
    public string incorrectMonologue;
    public bool isCorrectIngredient; // Check this in the Inspector for correct ones

    private bool hasBeenPicked = false; // To prevent multiple monologues if you pick it multiple times

    void Start()
    {
        // Find the MonologueManager if not assigned in Inspector
        if (monologueManager == null)
        {
            // --- This is the changed line ---
            monologueManager = FindFirstObjectByType<MonologueManager>(); 
            // ---------------------------------
            if (monologueManager == null)
            {
                Debug.LogError("MonologueManager not found in scene for Ingredient: " + gameObject.name);
            }
        }
    }

    // This method will be called by your Player script when Remy interacts with it
    public void PickIngredient()
    {
        if (hasBeenPicked) return; // Don't show monologue again if already picked

        if (monologueManager != null)
        {
            if (isCorrectIngredient)
            {
                monologueManager.ShowMonologue(correctMonologue);
            }
            else
            {
                monologueManager.ShowMonologue(incorrectMonologue);
            }
        }
        hasBeenPicked = true;
        // You might want to disable the collider or destroy the object here
        // GetComponent<Collider2D>().enabled = false;
    }
}