using UnityEngine;

public class Powers : MonoBehaviour
{
    public bool isNuke;
    public bool isInstaKill;
    public bool isArmor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            //if we made it this far, we collided with THE PLAYER SHIP
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }

    public void Nuke()
    {
        //wipes out entire map or clears round
        GetComponent<Ship>
        Destroy(gameObject);
    }

    public void InstaKill()
    {
        //normal shots are instakills...duh
    }

    public void Armor()
    {
        //regain health
    }

    //dont spawn after each round maybe alternate but the nuke is on a timer maybe
}
