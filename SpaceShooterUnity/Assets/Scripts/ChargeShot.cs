using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour
{
    public int damageToGive;

    [HideInInspector] public GameObject firingShip; //The ship that fired the projectile. This helps us avoid doing damage to the wrong ship.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING

        if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            //If we made it this far, the thing we collided with is a SHIP. WOOHOO! ANNNNNNDD, its not the ship that fired the projectile

            collision.GetComponent<Ship>().TakeDamage(damageToGive);

        }
    }
}
