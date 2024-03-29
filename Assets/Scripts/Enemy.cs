using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    Animator animator;
    
    private Rigidbody2D enemyRb;
    private PlayerController player;

    public float movespeed;
    private Vector3 directionPlayer;
    private Vector3 localScale;
    public gamemanager gameManager;
    public int pointvalue;

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

    public float health = 3;

   

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void Start()
    {
        
        enemyRb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        animator = GetComponent<Animator>();
        localScale = transform.localScale;

    }


    private void MoveEnemy()
    {
        directionPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionPlayer.x, directionPlayer.y) * movespeed;
            
    }

    private void LateUpdate()
    {
        if (enemyRb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if(enemyRb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }


    public void Defeated()
    {
        animator.SetTrigger("Defeated");
      
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointvalue);
        
    }
}
