using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class HoldToLoadLevel : MonoBehaviour
{
    [Header("Settings")]
    public float holdDuration = 1f;//how long we hold down for
    private float holdTimer = 0;// Tracks how long the button has been held
    private bool isHolding = false;

    [Header("UI")]
    public Image fillCircle; 

    public static event Action OnHoldComplete;// Event triggered when hold is completed successfully

    void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;// Increment timer by the time passed since last frame
            fillCircle.fillAmount = holdTimer / holdDuration;// Update UI circle fill based on progress

            if (holdTimer >= holdDuration)// Check if player held the button long enough
            {
                OnHoldComplete.Invoke();
                ResetHold();
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
        }
        else if (context.canceled)
        {
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillCircle.fillAmount = 0;
    }

}
