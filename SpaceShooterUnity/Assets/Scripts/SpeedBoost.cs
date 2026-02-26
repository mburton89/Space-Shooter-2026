using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public int speedToGain;

    //TODO: make it randomly spawn


    //this is how you collect it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we made it this far we collided with something

        if (collision.GetComponent<PlayerShip>())
        {
            //if we made it this far, the thing we collided with was the player ship
            
            //TODO: what it does
            //maybe use collision.GetComponent<PlayerShip>().____


            //TODO: how long it lasts

        }
    }
}
