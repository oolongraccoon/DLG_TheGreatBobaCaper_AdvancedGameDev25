using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public string gameSceneName = "FirstScene";
    public void StartGame()
    {

        // Restart the game
        SceneManager.LoadScene(gameSceneName);
    }

    public void Setting()
    {


    }
}


