using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
   
    public Meatbar meatbar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            meatbar.slider.value += 5;
        }
        
    }
}

