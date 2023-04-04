using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAMAGE : MonoBehaviour
{
    public PlayerController playerController;
    public int damage = 1;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController.TakeDamage(damage);
        }
    }
}
