using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Worm : MonoBehaviour
{

    public int healthtoGive; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING

        if (collision.GetComponent<PlayerShip>())
        {
            //If we made it this far, the thing we collided with is a SHIP. WOOHOO! ANNNNNNDD, its not the ship that fired the projectile

            collision.GetComponent<Ship>().RestoreHealth(healthtoGive);

            Destroy(gameObject);
        }
    }
}
