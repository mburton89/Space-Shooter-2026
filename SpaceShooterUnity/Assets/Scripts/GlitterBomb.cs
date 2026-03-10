using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.UI;

public class GlitterBomb : Projectile
{

    public GameObject glitterBombExplosionPrefab;
    public GameObject blastRadius;
    public Vector3 explosionPrefabRotation;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we made it this far, we collided with SOMETHING
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
        
        Instantiate(blastRadius, transform.position, transform.rotation);
        
        Destroy(newExplosion, 2);
    }



}
