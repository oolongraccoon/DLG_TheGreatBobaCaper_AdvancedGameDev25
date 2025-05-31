using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Persisting;

public class GameCotroller : MonoBehaviour
{
    public Inventory inventory;
    int progressAmount;
 
    void Start()
    {
        progressAmount = 0;
        Boba.OnBobaCollect += IncreaseProgressAmount;
        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;
    }
    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        if (progressAmount >= 4)
        {
            Debug.Log("level COMPLETE");
        }

    }
    void LoadNextLevel()
    {
        if (progressAmount >= 4)
        {
            LevelManagerPersist.instance.LoadLevel("SecondScene");
        }
        else
        {
            Debug.Log("Not enough progress yet!");
        }
    }

}
