using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto4_Boss : MonoBehaviour
{
    
    private Rigidbody2D enemyRb;
    public GameObject player;
    public float movespeed;
    private Vector3 directionPlayer;
 

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    

    private void FixedUpdate()
    {
        MoveBoss();
    }

    private void MoveBoss()
    {
        directionPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionPlayer.x, directionPlayer.y) * movespeed;
    }



    





    public void RemoveBoss()
    {
        Destroy(gameObject);
    }

   
}
