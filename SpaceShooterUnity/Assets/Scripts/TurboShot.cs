using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurboShot : MonoBehaviour
{
    public int damageToGive;
    [HideInInspector] public GameObject firingShip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            //If we made it this far, the thing we collided with is a SHIP. WOOHOO! ANNNNNNDD, its not the ship that fired the projectile

            collision.GetComponent<Ship>().TakeDamage(damageToGive);

            Destroy(gameObject);
        }
    }
}
