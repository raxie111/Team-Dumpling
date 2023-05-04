using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwordBoss : MonoBehaviour
{
    public int damageAmount = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object that has the "Boss" tag
        if (collision.gameObject.CompareTag("Boss"))
        {
            // Call the TakeDamage() function on the boss object with the damage amount
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(damageAmount);
        }
    }
}

