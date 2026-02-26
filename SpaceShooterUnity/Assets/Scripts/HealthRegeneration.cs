using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    public int healthToGain;
  

    //TODO add to powerup spawner

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we made it this far we collided with something

        if (collision.GetComponent<PlayerShip>())
        {
            //if we made it this far, the thing we collided with was the player ship

            collision.GetComponent<PlayerShip>().GiveHealth(healthToGain);

            Destroy(gameObject);


        }
    }
}
