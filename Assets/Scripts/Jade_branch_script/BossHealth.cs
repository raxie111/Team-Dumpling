using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
