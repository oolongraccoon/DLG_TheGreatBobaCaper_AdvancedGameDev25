using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class MonologueManager : MonoBehaviour
{
    public TMP_Text monologueText;
    public GameObject monologuePanel;
    public float autoHideDelay = 2f;


    public AudioClip monologueSound; // Sound to play on show
    private AudioSource audioSource;
    private CanvasGroup canvasGroup;


    public static MonologueManager instance;
    private Coroutine hideCoroutine;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        canvasGroup = monologuePanel.GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();


        if (canvasGroup != null)
            canvasGroup.alpha = 0f;


        monologuePanel.SetActive(false);
    }


    public void ShowMonologue(string message)
    {
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);


        monologueText.text = message;
        monologuePanel.SetActive(true);


        if (monologueSound != null && audioSource != null)
            audioSource.PlayOneShot(monologueSound);


        StartCoroutine(FadeCanvasGroup(0f, 1f, 0.5f)); // Fade in
        hideCoroutine = StartCoroutine(HideAfterDelay());
    }


    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(autoHideDelay);
        HideMonologue();
    }


    public void HideMonologue()
    {
        StartCoroutine(FadeCanvasGroup(1f, 0f, 0.5f)); // Fade out
    }


    private IEnumerator FadeCanvasGroup(float start, float end, float duration)
    {
        float t = 0f;


        if (canvasGroup == null)
        {
            monologuePanel.SetActive(end != 0f);
            yield break;
        }


        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
            yield return null;
        }


        canvasGroup.alpha = end;


        if (end == 0f)
            monologuePanel.SetActive(false);
    }
}
