using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDamagePower : MonoBehaviour
{
    public int giveDamage; //placeholder
    //make it randomly spawn


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we made it this far we collided with something

        if (collision.GetComponent<PlayerShip>())
        {
            //if we made it this far, the thing we collided with was the player ship

            //TODO: what does it do?
            //maybe use collision.GetComponent<PlayerShip>().____

            //TODO: how much health it gets rid of

        }
    }
}
