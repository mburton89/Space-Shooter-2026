using Unity.VisualScripting;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public bool isNuke;
    public bool isInstaKill;
    public bool isJug;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>() && isJug)
        {
            //if we made it this far, we collided with THE PLAYER SHIP
            collision.gameObject.GetComponent<PlayerShip>().JugHeal(2);
            
            Destroy(gameObject);
        }
    }

    //dont spawn after each round maybe alternate but the nuke is on a timer maybe
}
//for jug
    //needs to be able to read the current wave
    //in order to spawn every 3 waves
    //needs to spawn on the last baddieship destroyed
    //needs to heal you to the max