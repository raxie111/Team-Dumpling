using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Boss : MonoBehaviour
{
    public int initialHP = 25;
    private int currentHP;

    void Start()
    {
        currentHP = initialHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            currentHP -= 3;
            Debug.Log("Boss hit! Current HP: " + currentHP);

            if (currentHP <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Boss defeated!");
        Destroy(gameObject);
    }
}

