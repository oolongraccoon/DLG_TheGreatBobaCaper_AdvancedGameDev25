using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;


public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;


    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    public TMP_Text caughtMessageText;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }


    public void TriggerGameOver(string message = "Game Over!")
    {
        StartCoroutine(GameOverSequence(message));
    }
    private IEnumerator GameOverSequence(string msg)
    {
        caughtMessageText.text = "You were caught by the dog!";
        gameOverPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 0f; // Pause game
    }


    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
