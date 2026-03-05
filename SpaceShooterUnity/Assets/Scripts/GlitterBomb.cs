using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UI;

public class GlitterBomb : Projectile
{

    public GameObject glitterBombExplosionPrefab;
    public Vector3 explosionPrefabRotation;

    public Collider2D blastRadius;
    public Collider2D bombBody;

    private List<GameObject> inBlastRadius;

    private void Start()
    {
        inBlastRadius = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING
            // Check if collider is the bomb itself
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
        GameObject newExplosion = Instantiate(glitterBombExplosionPrefab, transform.position, Quaternion.Euler(explosionPrefabRotation));
        Destroy(newExplosion, 2);
    }

}
