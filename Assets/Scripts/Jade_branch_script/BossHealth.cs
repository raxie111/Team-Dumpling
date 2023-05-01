using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossHealth : MonoBehaviour
{
    public int maxHealth = 0;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Destroy the boss object
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object with the "Sword" tag
        if (collision.gameObject.CompareTag("Sword"))
        {
            // Deduct 1 health from the boss
            currentHealth -= 1;

            // Check if the boss's health has reached 0
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
}
