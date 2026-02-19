using JetBrains.Annotations;
using UnityEngine;

public class GlitterBomb : Projectile
{

    public GameObject glitterBombExplosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING

        Debug.Log("Collision!");

        if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            //If we made it this far, the thing we collided with is a SHIP. WOOHOO! ANNNNNNDD, its not the ship that fired the projectile

            collision.GetComponent<Ship>().TakeDamage(damageToGive);

            GlitterBombExplode();

            Destroy(gameObject);
        }
    }

    private void GlitterBombExplode()
    {
        GameObject newExplosion = Instantiate(glitterBombExplosionPrefab, transform.position, transform.rotation);
        Destroy(newExplosion, 2);
    }

}
