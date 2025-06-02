using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public HealthUI healthUI;

    private SpriteRenderer spriteRenderer;// Used to flash the player sprite red when damaged

    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();// Get sprite renderer component for color changes
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();// Check if collided object has an Enemy component
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);// Update the UI to reflect new health
        StartCoroutine(FlashRed());// Flash the player red to show damage visually
        if (currentHealth <= 0)
        {
            GameOverManager.instance.TriggerGameOver(); // Trigger game over
        }
    }
    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;// Change sprite color to red
        yield return new WaitForSeconds(0.1f);// Wait for 0.1 seconds
        spriteRenderer.color = Color.white;// Revert color back to white
    }
}
