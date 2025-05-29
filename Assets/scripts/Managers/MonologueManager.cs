using UnityEngine;
using TMPro; // Required for TextMeshPro UI elements
using System.Collections; // Required for Coroutines

public class MonologueManager : MonoBehaviour
{
    public TextMeshProUGUI monologueText; // Reference to your UI Text object
    public float displayDuration = 3f; // How long each monologue stays on screen

    private Coroutine currentMonologueCoroutine; // To keep track of running monologue

    void Awake()
    {
        // Ensure the text is hidden when the game starts
        if (monologueText != null)
        {
            monologueText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("MonologueText not assigned in MonologueManager!");
        }
    }

    public void ShowMonologue(string monologue)
    {
        // If a monologue is already displaying, stop it
        if (currentMonologueCoroutine != null)
        {
            StopCoroutine(currentMonologueCoroutine);
        }

        // Start the new monologue display
        currentMonologueCoroutine = StartCoroutine(DisplayMonologueRoutine(monologue));
    }

    private IEnumerator DisplayMonologueRoutine(string monologue)
    {
        monologueText.text = monologue; // Set the text
        monologueText.gameObject.SetActive(true); // Make the text visible

        yield return new WaitForSeconds(displayDuration); // Wait for the specified duration

        monologueText.gameObject.SetActive(false); // Hide the text
        currentMonologueCoroutine = null; // Clear the coroutine reference
    }
}