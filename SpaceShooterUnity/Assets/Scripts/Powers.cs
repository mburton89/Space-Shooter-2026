using UnityEngine;

public class Powers : MonoBehaviour
{

    public bool isNuke;
    public bool isInstaKill;
    public bool isArmor;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerShip>();
        {
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
        //kill lol
    }

    public void Armor()
    {
        //regain health
    }


    //alternate between each round, nuke should be on timer
        
    

}
