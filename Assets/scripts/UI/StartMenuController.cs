using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string gameSceneName = "FirstScene";

    public GameObject howToPlayPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void HowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }
}


