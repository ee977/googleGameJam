using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Set up variables for player health
    public int maxHealth = 100;
    public int currentHealth;
    public Text healthText;

    void Start()
    {
        // Set up the player's starting health
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount = 10)
    {
        // Reduce the player's health by the specified amount
        currentHealth -= damageAmount;

        // Update the health UI text
        UpdateHealthText();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle the player's death (e.g. respawn, game over screen, etc.)
        Debug.Log("Player has died!");
    }

    void UpdateHealthText()
    {
        // Update the health UI text
        healthText.text = "Health: " + currentHealth.ToString();
    }
}