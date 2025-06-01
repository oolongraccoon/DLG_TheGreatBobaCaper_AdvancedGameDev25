using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    [TextArea]
    public string monologueMessage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MonologueManager.instance.ShowMonologue(monologueMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MonologueManager.instance.HideMonologue();
        }
    }
}

