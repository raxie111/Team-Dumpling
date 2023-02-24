using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;


    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 1;

    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player_6");
        animator = GetComponent<Animator>();
    }


    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
