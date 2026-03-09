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

        if (collision.gameObject.GetComponent<PlayerShip>() && isNuke)
        {
            //if we made it this far, we collided with THE PLAYER SHIP
            collision.gameObject.GetComponent<PlayerShip>().NukeDestroy();

            Destroy(gameObject);
        }
    }

    //dont spawn after each round maybe alternate but the nuke is on a timers
}