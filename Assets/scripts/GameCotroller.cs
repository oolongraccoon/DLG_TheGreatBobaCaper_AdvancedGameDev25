using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Persisting;

public class GameCotroller : MonoBehaviour
{
    public Inventory inventory;
    int progressAmount; // Tracks the player's progress

    void Start()
    {
        progressAmount = 0;
        Boba.OnBobaCollect += IncreaseProgressAmount;
        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;// Subscribe to the event triggered when player holds to load next level
    }
    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        if (progressAmount >= 6)
        {
            Debug.Log("level COMPLETE");
        }

    }
    void LoadNextLevel()
    {
        if (progressAmount >= 6)
        {
            LevelManagerPersist.instance.LoadLevel("SecondScene");
        }
        else
        {
            Debug.Log("Not enough progress yet!");
        }
    }

}
