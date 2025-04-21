using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class InkUIManager : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSONAsset;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private GameObject choiceButtonPrefab;
    [SerializeField] private Transform choicesContainer;

    private Story story;

    void Start()
    {
        story = new Story(inkJSONAsset.text);
        RefreshView();
    }

    void RefreshView()
    {
        // Clear existing choices
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        // Display story text
        string text = "";
        while (story.canContinue)
        {
            text += story.Continue();
        }
        storyText.text = text;

        // Create buttons for choices
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonGO = Instantiate(choiceButtonPrefab, choicesContainer);
            TextMeshProUGUI buttonText = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text;

            Button button = buttonGO.GetComponent<Button>();
            int choiceIndex = choice.index; // Save to avoid closure issue
            button.onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        RefreshView();
    }
}
